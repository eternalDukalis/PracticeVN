using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {

	static int ClicksOnObjects = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	static public bool OnClick(GUITexture target)
	{
		if (PlayingPlatform.isPC())
		{
			if ((Input.GetKeyDown(KeyCode.Mouse0)) && (target.GetScreenRect().Contains(Input.mousePosition)))
			{
				ClicksOnObjects++;
				return true;
			}
		}
		if (PlayingPlatform.isMobile())
		{
			if ((Input.GetKeyDown(KeyCode.Mouse0)) && (target.GetScreenRect().Contains(Input.mousePosition)))
			{
				ClicksOnObjects++;
				return true;
			}
		}
		//Debug.Log (ClicksOnObjects);
		return false;
	}

	static public bool OnClick(GUIText target)
	{
		if (PlayingPlatform.isPC())
		{
			if ((Input.GetKeyDown(KeyCode.Mouse0)) && (target.GetScreenRect().Contains(Input.mousePosition)))
			{
				ClicksOnObjects++;
				return true;
			}
		}
		if (PlayingPlatform.isMobile())
		{
			if ((Input.GetKeyDown(KeyCode.Mouse0)) && (target.GetScreenRect().Contains(Input.mousePosition)))
			{
				ClicksOnObjects++;
				return true;
			}
		}
		return false;
	}

	static public bool OnPress(GUITexture target)
	{
		if (PlayingPlatform.isPC())
		{
			if ((Input.GetKey(KeyCode.Mouse0)) && (target.GetScreenRect().Contains(Input.mousePosition)))
			{
				ClicksOnObjects++;
				return true;
			}
		}
		if (PlayingPlatform.isMobile())
		{
			if ((Input.GetKey(KeyCode.Mouse0)) && (target.GetScreenRect().Contains(Input.mousePosition)))
			{
				ClicksOnObjects++;
				return true;
			}
		}
		return false;
	}

	static public bool MouseOver(GUITexture target)
	{
		if (target.GetScreenRect().Contains(Input.mousePosition))
			return true;
		return false;
	}

	static public bool MouseOver(GUIText target)
	{
		if (target.GetScreenRect().Contains(Input.mousePosition))
			return true;
		return false;
	}

	static public bool RandomClick()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			if (ClicksOnObjects==0)
				return true;
		}
		ClicksOnObjects = 0;
		return false;
	}
}
