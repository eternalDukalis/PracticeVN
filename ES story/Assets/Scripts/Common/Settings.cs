using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {

	static public bool MusicOn = true;
	static public bool EnvironmentOn = true;
	static public bool EffectsOn = true;
	static public int TextMode = 2;
	static public int AutoMode = 2;
	static public float TextSpeed = 0.075f;
	static public float AutoTime = 1;
	static public float AutoMultiplier = 0.03f;
	static public bool hasLoaded = false;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey("MusicOn"))
			MusicOn = PlayerPrefs.GetInt("MusicOn")==1;
		if (PlayerPrefs.HasKey("EnvironmentOn"))
			EnvironmentOn = PlayerPrefs.GetInt("EnvironmentOn")==1;
		if (PlayerPrefs.HasKey("EffectsOn"))
			EffectsOn = PlayerPrefs.GetInt("EffectsOn")==1;
		if (PlayerPrefs.HasKey("TextMode"))
			TextMode = PlayerPrefs.GetInt("TextMode");
		if (PlayerPrefs.HasKey("AutoMode"))
			AutoMode = PlayerPrefs.GetInt("AutoMode");
		if (PlayerPrefs.HasKey("MaxLevel"))
			Scenario.MaxLevel = PlayerPrefs.GetInt("MaxLevel");
		hasLoaded = true;
	}
	
	// Update is called once per frame
	void Update () {
		switch (TextMode)
		{
		case 1:
			TextSpeed = 0.025f;
			break;
		case 2:
			TextSpeed = 0.075f;
			break;
		case 3:
			TextSpeed = 0.125f;
			break;
		}
		switch (AutoMode)
		{
		case 1:
			AutoTime = 0.5f;
			AutoMultiplier = 0.02f;
			break;
		case 2:
			AutoTime = 1;
			AutoMultiplier = 0.03f;
			break;
		case 3:
			AutoTime = 1.5f;
			AutoMultiplier = 0.05f;
			break;
		}
	}
}
