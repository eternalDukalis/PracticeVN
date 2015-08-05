using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {

	public Color MouseOn;
	Color standartColor;
	Color CurrentColor;
	// Use this for initialization
	void Start () {
		standartColor = this.GetComponent<GUITexture>().color;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Click.OnClick(this.GetComponent<GUITexture>())) || (Input.GetKeyDown(KeyCode.Escape)))
			ExitBoard.isOnScreen = !ExitBoard.isOnScreen;
		if (PlayingPlatform.isPC())
		{
			if (Click.MouseOver(this.GetComponent<GUITexture>()))
				CurrentColor = MouseOn;
			else
				CurrentColor = standartColor;
			if (CurrentColor!=this.GetComponent<GUITexture>().color)
				this.GetComponent<GUITexture>().color = CurrentColor;
		}
	}
}
