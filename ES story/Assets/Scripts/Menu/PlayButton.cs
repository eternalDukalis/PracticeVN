using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	//GameObject mo;
	GameObject MMusic;
	// Use this for initialization
	void Start () {
		//mo = GameObject.FindGameObjectWithTag ("MenuObject");
		MMusic = GameObject.FindGameObjectWithTag ("MenuMusic");
	}
	
	// Update is called once per frame
	void Update () {
		if (!MMusic.GetComponent<AudioSource>().isPlaying)
			MMusic.GetComponent<AudioSource>().Play();
		if (Click.OnClick(this.GetComponent<GUIText>()))
		{
			MenuMoving mm = GameObject.FindObjectOfType<MenuMoving>();
			mm.XMove(-1);
		}
	}
}
