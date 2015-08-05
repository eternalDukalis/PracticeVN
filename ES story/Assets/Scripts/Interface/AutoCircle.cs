using UnityEngine;
using System.Collections;

public class AutoCircle : MonoBehaviour {

	private Color standartColor;
	public Color OnMouse;
	Color CurrentColor;
	// Use this for initialization
	void Start () {
		standartColor = this.GetComponent<GUITexture>().color;
		this.GetComponent<GUITexture>().color = new Color (0,0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManaging.AutoMode)
		{
			if (PlayingPlatform.isPC())
			{
				if (Click.MouseOver(this.GetComponent<GUITexture>()))
					CurrentColor = OnMouse;
				else
					CurrentColor = standartColor;
			}
			else
			{
				CurrentColor = standartColor;
			}
		}
		else
			CurrentColor = new Color(0,0,0,0);
		if (this.GetComponent<GUITexture>().color!=CurrentColor)
			this.GetComponent<GUITexture>().color = CurrentColor;
	}
}
