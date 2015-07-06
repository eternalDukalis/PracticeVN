using UnityEngine;
using System.Collections;

public class MenuMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.audio.mute = !Settings.MusicOn;
	}
}
