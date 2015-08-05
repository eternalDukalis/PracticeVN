using UnityEngine;
using System.Collections;

public class MenuMouseOn : MonoBehaviour {

	bool hasLoaded = false;
	public Color OnMouse;
	Color standartColor;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if ((!hasLoaded))
		{
			Init();
			hasLoaded = true;
		}
	}

	void OnGUI()
	{
		if ((Application.platform == RuntimePlatform.WindowsEditor) || (Application.platform == RuntimePlatform.WindowsPlayer))
			if (Click.MouseOver(this.GetComponent<GUIText>()))
				this.GetComponent<GUIText>().color = OnMouse;
			else
				this.GetComponent<GUIText>().color = standartColor;
	}

	void Init()
	{
		standartColor = this.GetComponent<GUIText>().color;
		OnMouse = new Color (OnMouse.r, OnMouse.g, OnMouse.b, standartColor.a);
	}
}
