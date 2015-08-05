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
		GUI.Label (new Rect(this.GetComponent<GUITexture>().GetScreenRect().x+TextBoard,Screen.height-this.GetComponent<GUITexture>().GetScreenRect().y-this.GetComponent<GUITexture>().GetScreenRect().height+TextBoard,this.GetComponent<GUITexture>().GetScreenRect().width-2*TextBoard,this.GetComponent<GUITexture>().GetScreenRect().height-2*TextBoard), GameManaging.Text, TextStyle);
	}
}
