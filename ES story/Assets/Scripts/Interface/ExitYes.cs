using UnityEngine;
using System.Collections;

public class ExitYes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Click.OnClick(this.GetComponent<GUIText>()))
		{
			ExitBoard.isOnScreen = false;
			Application.LoadLevel("menu");
		}
	}
}
