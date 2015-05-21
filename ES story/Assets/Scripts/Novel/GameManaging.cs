using UnityEngine;
using System.Collections;

public class GameManaging : MonoBehaviour {

	static public string Text = "default";
	static public string Author = "";
	static public Texture Background;
	static public bool CanDoNext = true;
	static public int GlobalTextInterval = 3;
	static GameObject thebackground;
	static GameObject oldBackground;
	// Use this for initialization
	void Start () {
		thebackground = GameObject.FindGameObjectWithTag ("Background");
		oldBackground = GameObject.FindGameObjectWithTag ("oldBackground");
		Background = thebackground.guiTexture.texture;
		Actor.gm = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		thebackground.guiTexture.texture = Background;
	}

	static public IEnumerator PushText(string s)
	{
		int TextInterval = 0;
		CanDoNext = false;
		Text = "";
		Author = "";
		while (Text.Length<s.Length) {
			TextInterval++;
			if (TextInterval>=GlobalTextInterval)
			{
				Text += s[Text.Length];
				TextInterval = 0;
			}
			if ((PressForward()) && (Text.Length>1))
			{
				Text = s;
				break;
			}
			yield return null;
		}
		yield return null;
		while (!PressForward()) {
			yield return null;
		}
		CanDoNext = true;
	}
	
	static public IEnumerator PushText(string s, string a)
	{
		int TextInterval = 0;
		CanDoNext = false;
		Text = "";
		Author = a;
		while (Text.Length<s.Length) {
			TextInterval++;
			if (TextInterval>=GlobalTextInterval)
			{
				Text += s[Text.Length];
				TextInterval = 0;
			}
			if ((PressForward()) && (Text.Length>1))
			{
				Text = s;
				break;
			}
			yield return null;
		}
		yield return null;
		while (!PressForward()) {
			yield return null;
		}
		CanDoNext = true;
	}

	static public IEnumerator ChangeBackground(string path)
	{
		CanDoNext = false;
		oldBackground.guiTexture.color = thebackground.guiTexture.color;
		oldBackground.guiTexture.texture = thebackground.guiTexture.texture;
		GameManaging.Background = Resources.LoadAssetAtPath<Texture> (path);
		while (oldBackground.guiTexture.color.a>=0) {
			if ((PressForward()) && (oldBackground.guiTexture.color.a<0.5f))
			{
				oldBackground.guiTexture.color = new Color(0,0,0,0);
			}
			oldBackground.guiTexture.color -= new Color(0,0,0,0.01f);
			yield return null;
		}
		CanDoNext = true;
	}

	static private bool PressForward()
	{
		if (Input.GetKeyDown (KeyCode.Space))
						return true;
		return false;
	}
}
