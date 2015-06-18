using UnityEngine;
using System.Collections;

public class AutoText : MonoBehaviour {

	private Color standartColor;
	public Color OnMouse;
	private GameObject myCircle;
	// Use this for initialization
	void Start () {
		standartColor = this.guiTexture.color;
		myCircle = GameObject.FindGameObjectWithTag("AutoCircle");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if ((Application.platform == RuntimePlatform.WindowsEditor) || (Application.platform == RuntimePlatform.WindowsPlayer))
			if (Click.MouseOver (myCircle.guiTexture)) 
			{
				this.guiTexture.color = OnMouse;
			} 
			else 
			{
				this.guiTexture.color = standartColor;
			}
	}
}
