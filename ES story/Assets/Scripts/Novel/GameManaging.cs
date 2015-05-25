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
	static public bool AutoMode = false;
	static public float AutoSpeed = 0.03f;
	static public float AutoInterval = 1;
	static public GameObject AutoButton;
	static private string BackgroundPath = "Graphics/Backgrounds/";
	static public float FadeSpeed = 0.035f;
	void Start () {
		thebackground = GameObject.FindGameObjectWithTag ("Background");
		oldBackground = GameObject.FindGameObjectWithTag ("oldBackground");
		LeftArrow = GameObject.FindGameObjectWithTag ("LeftArrow");
		RightArrow = GameObject.FindGameObjectWithTag ("RightArrow");
		SkipArrow = GameObject.FindGameObjectWithTag ("Skip");
		AutoButton = GameObject.FindGameObjectWithTag ("AutoCircle");
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
		if ((!BackMode) && (PressAuto()))
			AutoMode = !AutoMode;
		if (AutoMode)
		{
			if ((PressForward()) || (PressLeft()) || (PressRight()) || (PressSkip()))
				AutoMode = false;
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
		if (!AutoMode)
		{
			while (((!PressForward()) && (!PressSkip()) && (!PressAuto())) || (BackMode)) {
				yield return null;
			}
		}
		else
			yield return new WaitForSeconds(AutoInterval + Text.Length*AutoSpeed);
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
		if (!AutoMode)
		{
			while (((!PressForward()) && (!PressSkip()) && (!PressAuto())) || (BackMode)) {
				yield return null;
			}
		}
		else
			yield return new WaitForSeconds(AutoInterval + Text.Length*AutoSpeed);
		CanDoNext = true;
	}

	static public IEnumerator ChangeBackground(string path)
	{

		CanDoNext = false;
		oldBackground.guiTexture.color = thebackground.guiTexture.color;
		oldBackground.guiTexture.texture = thebackground.guiTexture.texture;
		GameManaging.Background = Resources.Load<Texture>(BackgroundPath + path);
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

	static public IEnumerator ShowDay(string whattoshow, string initialBackground)
	{
		float TimeToShow = 3;
		float fontSizeMulitplier = 0.15f;
		CanDoNext = false;
		Text = "";
		Author = "";
		GameObject DayBack = new GameObject("dayback",typeof(GUITexture));
		DayBack.guiTexture.texture = Resources.Load<Texture>(BackgroundPath + initialBackground);
		DayBack.transform.position = new Vector3 (0.5f, 0.5f, 15);
		DayBack.transform.localScale = new Vector3 (1, 1, 0);
		DayBack.guiTexture.color = new Color (0, 0, 0, 0);
		while (DayBack.guiTexture.color.a<1)
		{
			DayBack.guiTexture.color += new Color(0,0,0,FadeSpeed);
			yield return null;
		}
		GameObject DayText = new GameObject ("daytext", typeof(GUIText));
		DayText.guiText.color = new Color (1, 1, 1, 0);
		DayText.transform.position = new Vector3 (0.5f, 0.5f, 16);
		DayText.guiText.alignment = TextAlignment.Center;
		DayText.guiText.anchor = TextAnchor.MiddleCenter;
		DayText.guiText.fontStyle = FontStyle.Bold;
		DayText.guiText.fontSize = (int)(Screen.height * fontSizeMulitplier);
		DayText.guiText.text = whattoshow;
		while (DayText.guiText.color.a<1)
		{
			DayText.guiText.color += new Color(0,0,0,FadeSpeed);
			yield return null;
		}
		Background = Resources.Load<Texture>(BackgroundPath + initialBackground);
		yield return new WaitForSeconds(TimeToShow);
		while (DayText.guiText.color.a>0)
		{
			DayText.guiText.color -= new Color(0,0,0,FadeSpeed);
			yield return null;
		}
		while (DayBack.guiTexture.color.a>0)
		{
			DayBack.guiTexture.color -= new Color(0,0,0,FadeSpeed);
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

	static public bool PressAuto()
	{
		if ((Input.GetKeyDown(KeyCode.A)) || (Click.OnClick(AutoButton.guiTexture)))
			return true;
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
