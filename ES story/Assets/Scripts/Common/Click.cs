using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	static public bool OnClick(GUITexture target)
	{
		if ((Application.platform==RuntimePlatform.WindowsEditor) || (Application.platform==RuntimePlatform.WindowsPlayer))
		{
			if ((Input.GetKeyDown(KeyCode.Mouse0)) && (target.GetScreenRect().Contains(Input.mousePosition)))
				return true;
		}
		if (Application.platform==RuntimePlatform.Android)
		{
			if ((Input.GetKeyDown(KeyCode.Mouse0)) && (target.GetScreenRect().Contains(Input.mousePosition)))
				return true;
		}
		return false;
	}

	static public bool OnPress(GUITexture target)
	{
		if ((Application.platform==RuntimePlatform.WindowsEditor) || (Application.platform==RuntimePlatform.WindowsPlayer))
		{
			if ((Input.GetKey(KeyCode.Mouse0)) && (target.GetScreenRect().Contains(Input.mousePosition)))
				return true;
		}
		if (Application.platform==RuntimePlatform.Android)
		{
			if ((Input.GetKey(KeyCode.Mouse0)) && (target.GetScreenRect().Contains(Input.mousePosition)))
				return true;
		}
		return false;
	}

	static public bool MouseOver(GUITexture target)
	{
		if (target.GetScreenRect().Contains(Input.mousePosition))
			return true;
		return false;
	}

}
