using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {

	public Color MouseOn;
	Color standartColor;
	// Use this for initialization
	void Start () {
		standartColor = this.guiTexture.color;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Click.OnClick(this.guiTexture)) || (Input.GetKeyDown(KeyCode.Escape)))
			ExitBoard.isOnScreen = !ExitBoard.isOnScreen;
	}

	void OnGUI()
	{
		if ((Application.platform == RuntimePlatform.WindowsEditor) || (Application.platform == RuntimePlatform.WindowsPlayer))
			if (Click.MouseOver(this.guiTexture))
				this.guiTexture.color = MouseOn;
			else
				this.guiTexture.color = standartColor;
	}
}
