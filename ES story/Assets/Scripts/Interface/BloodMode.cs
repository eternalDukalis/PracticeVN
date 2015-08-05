using UnityEngine;
using System.Collections;

public class BloodMode : MonoBehaviour {

	Color StandartColor;
	Color CurrentColor;
	// Use this for initialization
	void Start () {
		StandartColor = this.GetComponent<GUITexture>().color;
		this.GetComponent<GUITexture>().color = new Color (0, 0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManaging.BloodMode)
			CurrentColor = StandartColor;
		else
			CurrentColor = new Color(0,0,0,0);
		if (this.GetComponent<GUITexture>().color != CurrentColor)
			this.GetComponent<GUITexture>().color = CurrentColor;
	}
}
