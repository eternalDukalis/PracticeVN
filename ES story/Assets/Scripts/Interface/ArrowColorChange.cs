using UnityEngine;
using System.Collections;

public class ArrowColorChange : MonoBehaviour {

	Color CurrentColor;
	Color StandartColor;
	public Color OnMouse;
	// Use this for initialization
	void Start () {
		StandartColor = this.guiTexture.color;
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayingPlatform.isPC())
		{
			if (Click.MouseOver(this.guiTexture))
				CurrentColor = OnMouse;
			else
				CurrentColor = StandartColor;
			if (CurrentColor!=this.guiTexture.color)
				this.guiTexture.color = CurrentColor;
		}
	}
}
