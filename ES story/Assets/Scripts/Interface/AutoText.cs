using UnityEngine;
using System.Collections;

public class AutoText : MonoBehaviour {

	private Color standartColor;
	public Color OnMouse;
	private GameObject myCircle;
	Color CurrentColor;
	// Use this for initialization
	void Start () {
		standartColor = this.guiTexture.color;
		myCircle = GameObject.FindGameObjectWithTag("AutoCircle");
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayingPlatform.isPC())
		{
			if (Click.MouseOver (myCircle.guiTexture)) 
			{
				CurrentColor = OnMouse;
			} 
			else 
			{
				CurrentColor = standartColor;
			}
		}
		if (this.guiTexture.color!=CurrentColor)
			this.guiTexture.color = CurrentColor;
	}
}
