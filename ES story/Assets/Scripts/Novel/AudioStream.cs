using UnityEngine;
using System.Collections;

public class AudioStream {
	GameObject MainSound;
	GameObject OldSound;
	bool itsloop = false;
	string spath;
	float thevol;

	static public float FadeOutSpeed = 0.01f;
	static public GameManaging gm;
	public AudioStream()
	{
	}

	public AudioStream(string path, bool isLooped, float volume)
	{
		spath = path;
		itsloop = isLooped;
		thevol = volume;
	}

	public void Play(string title)
	{
		gm.StartCoroutine (play (title));
	}

	private IEnumerator play(string title)
	{

		//MonoBehaviour.Destroy(MainSound);
		MainSound = new GameObject(title,typeof(AudioSource));
		MainSound.GetComponent<AudioSource>().playOnAwake = false;
		MainSound.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>(spath+title);
		MainSound.transform.position = new Vector3(0,0,-8);
		MainSound.GetComponent<AudioSource>().loop = itsloop;
		MainSound.GetComponent<AudioSource>().volume = thevol;
		while (!MainSound.GetComponent<AudioSource>().clip.isReadyToPlay)
		{
			Debug.Log("lil");
			yield return null;
		}
		MainSound.GetComponent<AudioSource>().Play();
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
		while (currentStream.GetComponent<AudioSource>().volume>0) 
		{
			currentStream.GetComponent<AudioSource>().volume -= FadeOutSpeed;
			yield return null;
		}
		MonoBehaviour.Destroy (currentStream);
	}
}
