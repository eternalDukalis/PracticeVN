using UnityEngine;
using System.Collections;

public class SettingMulti : MonoBehaviour {

	public int Mode;
	public bool isText;
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
			if (isText)
			{
				Settings.TextMode = Mode;
				PlayerPrefs.SetInt("TextMode",Settings.TextMode);
			}
			else
			{
				Settings.AutoMode = Mode;
				PlayerPrefs.SetInt("AutoMode",Settings.AutoMode);
			}
		}
	}

	void OnGUI()
	{
		bool condition = true;
		if (isText)
			condition = Mode==Settings.TextMode;
		else
			condition = Mode==Settings.AutoMode;
		if (condition)
			this.GetComponent<GUIText>().color = standartColor;
		else
			this.GetComponent<GUIText>().color = unavailableColor;
		if ((Application.platform == RuntimePlatform.WindowsEditor) || (Application.platform == RuntimePlatform.WindowsPlayer))
			if (Click.MouseOver(this.GetComponent<GUIText>()))
				this.GetComponent<GUIText>().color = this.GetComponent<GUIText>().color*MouseOn;
	}
}
