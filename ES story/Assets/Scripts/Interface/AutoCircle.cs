using UnityEngine;
using System.Collections;

public class AutoCircle : MonoBehaviour {

	private Color standartColor;
	// Use this for initialization
	void Start () {
		standartColor = this.guiTexture.color;
		this.guiTexture.color = new Color (0,0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if (GameManaging.AutoMode)
		{
			if (Click.MouseOver(this.guiTexture))
				this.guiTexture.color = standartColor;
			else
				this.guiTexture.color = standartColor - new Color(0,0,0,standartColor.a*0.75f);
		}
		else
			this.guiTexture.color = new Color(0,0,0,0);
	}
}
