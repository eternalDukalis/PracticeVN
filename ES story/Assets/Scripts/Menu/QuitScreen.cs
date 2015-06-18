using UnityEngine;
using System.Collections;

public class QuitScreen : MonoBehaviour {

	Color standartColor;
	// Use this for initialization
	void Start () {
		standartColor = new Color(0.5f,0.5f,0.5f,0.5f);
		this.guiTexture.color = new Color (0, 0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MakeVisible()
	{
		this.guiTexture.color = standartColor;
	}
}
