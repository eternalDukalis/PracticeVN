using UnityEngine;
using System.Collections;

public class BackModeEffect : MonoBehaviour {

	Color Invis;
	Color Vis;
	Color CurrentColor;
	// Use this for initialization
	void Start () {
		Vis = this.guiTexture.color;
		Invis = new Color (0, 0, 0, 0);
		this.guiTexture.color = Invis;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManaging.BackMode)
			CurrentColor = Vis;
		else
			CurrentColor = Invis;
		if (CurrentColor!=this.guiTexture.color)
			this.guiTexture.color = CurrentColor;
	}
}
