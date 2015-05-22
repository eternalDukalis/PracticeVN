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
	static public bool BackMode = false;
	static public StackText stText;
	static int currentBack = 0; 
	static string originalString = "";
	static GameObject LeftArrow;
	static GameObject RightArrow;
	static GameObject SkipArrow;
	static Color StandartColor;
	static public float SkipInterval = 1;
	// Use this for initialization
	void Start () {
		thebackground = GameObject.FindGameObjectWithTag ("Background");
		oldBackground = GameObject.FindGameObjectWithTag ("oldBackground");
		LeftArrow = GameObject.FindGameObjectWithTag ("LeftArrow");
		RightArrow = GameObject.FindGameObjectWithTag ("RightArrow");
		SkipArrow = GameObject.FindGameObjectWithTag ("Skip");
		Background = thebackground.guiTexture.texture;
		Actor.gm = this;
		AudioStream.gm = this;
		stText = new StackText ();
		StandartColor = LeftArrow.guiTexture.color;
	}
	
	// Update is called once per frame
	void Update () {
		if ((PressLeft()) && (!BackMode))
		{
			BackMode = true;
			currentBack = 0;
			originalString = Text;
		}
		if (BackMode)
		{
			if ((PressLeft()) && (currentBack<stText.Size-1))
			{
				currentBack++;
				Text = stText.GetString(currentBack);
				Author = stText.GetAuthor(currentBack);
			}
			if ((PressRight()))
			{
				if (currentBack>0)
				{
					currentBack--;
					Text = stText.GetString(currentBack);
					Author = stText.GetAuthor(currentBack);
				}
				else
				{
					Text = originalString;
					BackMode = false;
				}
			}
			if (PressForward())
			{
				Text = originalString;
				BackMode = false;
			}
		}
	}

	void OnGUI()
	{
		thebackground.guiTexture.texture = Background;
		if ((Application.platform==RuntimePlatform.WindowsEditor) || (Application.platform==RuntimePlatform.WindowsPlayer))
		{
			DependOnMouse(SkipArrow);
			DependOnMouse(LeftArrow);
			DependOnMouse(RightArrow);
		}
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
			if (((PressForward()) || (PressSkip())) && (Text.Length>1))
			{
				Text = s;
				break;
			}
			yield return null;
		}
		yield return null;
		while (((!PressForward()) && (!PressSkip())) || (BackMode)) {
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
			if (((PressForward()) || (PressSkip())) && (Text.Length>1))
			{
				Text = s;
				break;
			}
			yield return null;
		}
		yield return null;
		while (((!PressForward()) && (!PressSkip())) || (BackMode)) {
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
			if (((PressForward()) || (PressSkip())) && (oldBackground.guiTexture.color.a<0.5f) && (!BackMode))
			{
				oldBackground.guiTexture.color = new Color(0,0,0,0);
			}
			oldBackground.guiTexture.color -= new Color(0,0,0,0.01f);
			yield return null;
		}
		CanDoNext = true;
	}

	static public bool PressForward()
	{
		if ((Input.GetKeyDown (KeyCode.Space)) || (Input.GetKeyDown(KeyCode.Return)) || ((PressRight()) && (!BackMode)))
			return true;
		return false;
	}

	static public bool PressLeft()
	{
		if ((Input.GetKeyDown(KeyCode.LeftArrow)) || (Click.OnClick(LeftArrow.guiTexture)))
		    return true;
		return false;
	}

	static public bool PressRight()
	{
		if ((Input.GetKeyDown(KeyCode.RightArrow)) || (Click.OnClick(RightArrow.guiTexture)))
			return true;
		return false;
	}

	static public bool PressSkip()
	{
		if ((Input.GetKey (KeyCode.LeftControl)) || (Click.OnPress(SkipArrow.guiTexture)))
		{
			return true;
		}
		return false;
	}

	static private void DependOnMouse(GameObject target)
	{
		if (Click.MouseOver(target.guiTexture))
			target.guiTexture.color = StandartColor;
		else
			target.guiTexture.color = StandartColor - new Color(0,0,0,StandartColor.a*0.75f);
	}
}
