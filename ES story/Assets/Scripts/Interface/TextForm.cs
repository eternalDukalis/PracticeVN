using UnityEngine;
using System.Collections;

public class TextForm : MonoBehaviour {

	public float YScale = 0.2f;
	public float TextBoard;
	public float TextSize;
	public GUIStyle TextStyle;
	void Start ()
	{
		TextBoard *= Screen.height;
		TextStyle.fontSize = (int)(TextSize * Screen.height);
		//this.transform.localScale = new Vector3 (YScale*this.guiTexture.texture.width * Screen.height / this.guiTexture.texture.height / Screen.width, YScale, 0);

	}

	void Update () 
	{
	
	}

	void OnGUI()
	{
		GUI.Label (new Rect(this.guiTexture.GetScreenRect().x+TextBoard,Screen.height-this.guiTexture.GetScreenRect().y-this.guiTexture.GetScreenRect().height+TextBoard,this.guiTexture.GetScreenRect().width-2*TextBoard,this.guiTexture.GetScreenRect().height-2*TextBoard), GameManaging.Text, TextStyle);
	}
}
