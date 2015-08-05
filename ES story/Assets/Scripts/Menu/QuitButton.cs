using UnityEngine;
using System.Collections;

public class QuitButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Click.OnClick(this.GetComponent<GUIText>()))
		{
			QuitScreen scr = GameObject.FindObjectOfType<QuitScreen>();
			scr.MakeVisible();
			Application.Quit();
		}
	}
}
