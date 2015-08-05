using UnityEngine;
using System.Collections;

public class AutoText : MonoBehaviour {

	private Color standartColor;
	public Color OnMouse;
	private GameObject myCircle;
	Color CurrentColor;
	// Use this for initialization
	void Start () {
		standartColor = this.GetComponent<GUITexture>().color;
		CurrentColor = standartColor;
		myCircle = GameObject.FindGameObjectWithTag("AutoCircle");
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayingPlatform.isPC())
		{
			if (Click.MouseOver (myCircle.GetComponent<GUITexture>())) 
			{
				CurrentColor = OnMouse;
			} 
			else 
			{
				CurrentColor = standartColor;
			}
		}
		if (this.GetComponent<GUITexture>().color!=CurrentColor)
			this.GetComponent<GUITexture>().color = CurrentColor;
	}
}
