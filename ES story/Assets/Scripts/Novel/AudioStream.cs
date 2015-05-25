using UnityEngine;
using System.Collections;

public class AudioStream {
	GameObject MainSound;
	GameObject OldSound;
	bool itsloop = false;
	string spath;

	static public float FadeOutSpeed = 0.01f;
	static public GameManaging gm;
	public AudioStream()
	{
	}

	public AudioStream(string path, bool isLooped)
	{
		spath = path;
		itsloop = isLooped;
	}

	public void Play(string title)
	{
		gm.StartCoroutine (play (title));
	}

	private IEnumerator play(string title)
	{

		//MonoBehaviour.Destroy(MainSound);
		MainSound = new GameObject(title,typeof(AudioSource));
		MainSound.audio.playOnAwake = false;
		MainSound.audio.clip = Resources.Load<AudioClip>(spath+title);
		MainSound.transform.position = new Vector3(0,0,-8);
		MainSound.audio.loop = itsloop;
		while (!MainSound.audio.clip.isReadyToPlay)
		{
			Debug.Log("lil");
			yield return null;
		}
		MainSound.audio.Play();
	}

	public void Stop()
	{
		gm.StartCoroutine (FadeOut (MainSound));
	}

	public void ChangeSound(string title)
	{
		OldSound = MainSound;
		gm.StartCoroutine (FadeOut (OldSound));
		Play (title);
	}

	private IEnumerator FadeOut(GameObject currentStream)
	{
		while (currentStream.audio.volume>0) 
		{
			currentStream.audio.volume -= FadeOutSpeed;
			yield return null;
		}
		MonoBehaviour.Destroy (currentStream);
	}
}
