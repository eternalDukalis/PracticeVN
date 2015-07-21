using UnityEngine;
using System.Collections;

public class PlayingPlatform : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	static public bool isPC()
	{
		if (Application.platform==RuntimePlatform.WindowsEditor)
			return true;
		if (Application.platform==RuntimePlatform.WindowsPlayer)
			return true;
		if (Application.platform==RuntimePlatform.LinuxPlayer)
			return true;
		if (Application.platform==RuntimePlatform.OSXPlayer)
			return true;
		return false;
	}

	static public bool isMobile()
	{
		if (Application.platform==RuntimePlatform.Android)
			return true;
		if (Application.platform==RuntimePlatform.IPhonePlayer)
			return true;
		return false;
	}
}
