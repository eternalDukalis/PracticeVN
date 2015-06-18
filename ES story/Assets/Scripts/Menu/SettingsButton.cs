using UnityEngine;
using System.Collections;

public class SettingsButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Click.OnClick(this.guiText))
		{
			MenuMoving mm = GameObject.FindObjectOfType<MenuMoving>();
			mm.YMove(1);
		}
	}
}
