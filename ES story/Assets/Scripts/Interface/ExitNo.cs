using UnityEngine;
using System.Collections;

public class ExitNo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Click.OnClick(this.guiText))
			ExitBoard.isOnScreen = false;
	}
}
