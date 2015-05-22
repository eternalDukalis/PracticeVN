using UnityEngine;
using System.Collections;

public class BackModeEffect : MonoBehaviour {

	Color Invis;
	Color Vis;
	// Use this for initialization
	void Start () {
		Vis = this.guiTexture.color;
		Invis = new Color (0, 0, 0, 0);
		this.guiTexture.color = Invis;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI()
	{
		if (GameManaging.BackMode)
			this.guiTexture.color = Vis;
		else
			this.guiTexture.color = Invis;
	}
}
