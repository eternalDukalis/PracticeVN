using UnityEngine;
using System.Collections;

public class AudioStream {
	GameObject MainSound;
	GameObject OldSound;
	bool itsloop = false;

	struct SingleSound { public string Name; public string Path; };
	SingleSound[] Library;

	static public float FadeOutSpeed = 0.01f;
	static public GameManaging gm;
	public AudioStream()
	{
	}

	public AudioStream(string path, bool isLooped)
	{
		string[] cursound = System.IO.Directory.GetFiles (path,"*.mp3");
		Library = new SingleSound[cursound.Length];
		for (int i=0; i<cursound.Length; i++) 
		{
			Library[i].Name = cursound[i].Remove(cursound[i].Length-4).Remove(0,path.Length);
			Library[i].Path = cursound[i];
		}
		itsloop = isLooped;
	}

	public void Play(string title)
	{
		for (int i=0; i<Library.Length; i++) 
			if (Library [i].Name == title) 
			{
				//MonoBehaviour.Destroy(MainSound);
				MainSound = new GameObject(Library[i].Name,typeof(AudioSource));
				MainSound.audio.playOnAwake = false;
				MainSound.audio.clip = Resources.LoadAssetAtPath<AudioClip>(Library[i].Path);
				MainSound.transform.position = new Vector3(0,0,-8);
				MainSound.audio.loop = itsloop;
				break;
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
