using UnityEngine;
using System.Collections;

public class BloodMode : MonoBehaviour {

	Color StandartColor;
	// Use this for initialization
	void Start () {
		StandartColor = this.guiTexture.color;
		this.guiTexture.color = new Color (0, 0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if (GameManaging.BloodMode)
			this.guiTexture.color = StandartColor;
		else
			this.guiTexture.color = new Color(0,0,0,0);
	}
}
