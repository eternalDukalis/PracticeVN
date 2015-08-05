using UnityEngine;
using System.Collections;

public class SettingsSwitcher : MonoBehaviour {

	public bool isOn;
	public enum ToSwitch {Music, Environment, Sound };
	public ToSwitch WhatToSwitch;
	public Color unavailableColor;
	public Color MouseOn;
	Color standartColor;
	// Use this for initialization
	void Start () {
		standartColor = this.GetComponent<GUIText>().color;
		OnGUI ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Click.OnClick(this.GetComponent<GUIText>()))
		{
			switch (WhatToSwitch)
			{
				case ToSwitch.Music:
					Settings.MusicOn = isOn;
					PlayerPrefs.SetInt("MusicOn",Settings.MusicOn.GetHashCode());
					break;
				case ToSwitch.Environment:
					Settings.EnvironmentOn = isOn;
					PlayerPrefs.SetInt("EnvironmentOn",Settings.MusicOn.GetHashCode());
					break;
				case ToSwitch.Sound:
					Settings.EffectsOn = isOn;
					PlayerPrefs.SetInt("EffectsOn",Settings.MusicOn.GetHashCode());
					break;
			}
		}
	}

	void OnGUI()
	{
		bool condition = true;
		switch (WhatToSwitch)
		{
		case ToSwitch.Music:
			condition = isOn==Settings.MusicOn;
			break;
		case ToSwitch.Environment:
			condition = isOn==Settings.EnvironmentOn;
			break;
		case ToSwitch.Sound:
			condition = isOn==Settings.EffectsOn;
			break;
		}
		if (condition)
			this.GetComponent<GUIText>().color = standartColor;
		else
			this.GetComponent<GUIText>().color = unavailableColor;
		if ((Application.platform == RuntimePlatform.WindowsEditor) || (Application.platform == RuntimePlatform.WindowsPlayer))
			if (Click.MouseOver(this.GetComponent<GUIText>()))
				this.GetComponent<GUIText>().color = this.GetComponent<GUIText>().color*MouseOn;
	}
}
