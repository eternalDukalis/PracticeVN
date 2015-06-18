using UnityEngine;
using System.Collections;

public class MenuBack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Click.OnClick(this.guiText))
		{
			MenuMoving mm = GameObject.FindObjectOfType<MenuMoving>();
			mm.XMove(0);
			mm.YMove(0);
		}
	}
}
