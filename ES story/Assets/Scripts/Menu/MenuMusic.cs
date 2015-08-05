using UnityEngine;
using System.Collections;

public class MenuMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<AudioSource>().mute = true;
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<AudioSource>().mute = !Settings.MusicOn;
	}
}
