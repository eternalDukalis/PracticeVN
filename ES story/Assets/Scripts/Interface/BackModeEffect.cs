using UnityEngine;
using System.Collections;

public class BackModeEffect : MonoBehaviour {

	Color Invis;
	Color Vis;
	Color CurrentColor;
	// Use this for initialization
	void Start () {
		Vis = this.GetComponent<GUITexture>().color;
		Invis = new Color (0, 0, 0, 0);
		this.GetComponent<GUITexture>().color = Invis;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManaging.BackMode)
			CurrentColor = Vis;
		else
			CurrentColor = Invis;
		if (CurrentColor!=this.GetComponent<GUITexture>().color)
			this.GetComponent<GUITexture>().color = CurrentColor;
	}
}
