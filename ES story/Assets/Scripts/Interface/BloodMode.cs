using UnityEngine;
using System.Collections;

public class BloodMode : MonoBehaviour {

	Color StandartColor;
	Color CurrentColor;
	// Use this for initialization
	void Start () {
		StandartColor = this.guiTexture.color;
		this.guiTexture.color = new Color (0, 0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManaging.BloodMode)
			CurrentColor = StandartColor;
		else
			CurrentColor = new Color(0,0,0,0);
		if (this.guiTexture.color != CurrentColor)
			this.guiTexture.color = CurrentColor;
	}
}
