using UnityEngine;
using System.Collections;

public class ArrowColorChange : MonoBehaviour {

	Color CurrentColor;
	Color StandartColor;
	public Color OnMouse;
	// Use this for initialization
	void Start () {
		StandartColor = this.GetComponent<GUITexture>().color;
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayingPlatform.isPC())
		{
			if (Click.MouseOver(this.GetComponent<GUITexture>()))
				CurrentColor = OnMouse;
			else
				CurrentColor = StandartColor;
			if (CurrentColor!=this.GetComponent<GUITexture>().color)
				this.GetComponent<GUITexture>().color = CurrentColor;
		}
	}
}
