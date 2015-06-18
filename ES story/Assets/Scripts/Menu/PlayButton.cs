using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	//GameObject mo;
	// Use this for initialization
	void Start () {
		//mo = GameObject.FindGameObjectWithTag ("MenuObject");
	}
	
	// Update is called once per frame
	void Update () {
		if (Click.OnClick(this.guiText))
		{
			MenuMoving mm = GameObject.FindObjectOfType<MenuMoving>();
			mm.XMove(-1);
		}
	}
}
