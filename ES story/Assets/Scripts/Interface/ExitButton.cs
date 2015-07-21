using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {

	public Color MouseOn;
	Color standartColor;
	Color CurrentColor;
	// Use this for initialization
	void Start () {
		standartColor = this.guiTexture.color;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Click.OnClick(this.guiTexture)) || (Input.GetKeyDown(KeyCode.Escape)))
			ExitBoard.isOnScreen = !ExitBoard.isOnScreen;
		if (PlayingPlatform.isPC())
		{
			if (Click.MouseOver(this.guiTexture))
				CurrentColor = MouseOn;
			else
				CurrentColor = standartColor;
			if (CurrentColor!=this.guiTexture.color)
				this.guiTexture.color = CurrentColor;
		}
	}
}
