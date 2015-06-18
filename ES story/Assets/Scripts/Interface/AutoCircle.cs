using UnityEngine;
using System.Collections;

public class AutoCircle : MonoBehaviour {

	private Color standartColor;
	public Color OnMouse;
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
			if ((Application.platform == RuntimePlatform.WindowsEditor) || (Application.platform == RuntimePlatform.WindowsPlayer))
			{
				if (Click.MouseOver(this.guiTexture))
					this.guiTexture.color = OnMouse;
				else
					this.guiTexture.color = standartColor;
			}
			else
			{
				this.guiTexture.color = standartColor;
			}
		}
		else
			this.guiTexture.color = new Color(0,0,0,0);
	}
}
