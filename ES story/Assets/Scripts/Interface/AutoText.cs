using UnityEngine;
using System.Collections;

public class AutoText : MonoBehaviour {

	private Color standartColor;
	private GameObject myCircle;
	// Use this for initialization
	void Start () {
		standartColor = this.guiText.color;
		this.guiText.color = standartColor - new Color(0,0,0,standartColor.a*0.75f);
		myCircle = GameObject.FindGameObjectWithTag("AutoCircle");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if (Click.MouseOver(myCircle.guiTexture))
			this.guiText.color = standartColor;
		else
			this.guiText.color = standartColor - new Color(0,0,0,standartColor.a*0.75f);
	}
}
