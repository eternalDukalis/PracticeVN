using UnityEngine;
using System.Collections;

public class GameManaging : MonoBehaviour {

	static public string Text = "";
	static public string Author = "";
	//static public Texture Background;
	static public bool CanDoNext = true;
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
	static public GameObject AutoButton;
	static private string BackgroundPath = "Graphics/Backgrounds/";
	static public float FadeSpeed = 0.035f;
	static public bool BloodMode = false;
	static string targetText;
	static string titresText = "Спасибо за прочтение! \n " +
		"История полностью вымышлена,\n" +
		"все совпадения с реальностью случайны.\n" +
		"\n" +
		"Также разработчик не претендует на\n" +
		"обладание контентом. Все права\n" +
		"принадлежат изначальным авторам.\n" +
		"\n" +
		"Буду надеяться на то, что вам понравилось,\n" +
		"а также на конструкивную критику.\n" +
		"\n" +
		"РАЗРАБОТЧИК\n" +
		"Dukalis Game Dev Studio\n" +
		"\n" +
		"АВТОР СЦЕНАРИЯ\n" +
		"eternalDukalis\n" +
		"\n" +
		"ОРИГИНАЛЬНАЯ ВСЕЛЕННАЯ\n" +
		"Бесконечное Лето\n" +
		"\n" +
		"АВТОРЫ ОРИГИНАЛЬНОГО СЦЕНАРИЯ\n" +
		"Soviet Games\n" +
		"\n" +
		"ГРАФИКА\n" +
		"Soviet Games\n" +
		"\n" +
		"МУЗЫКА ИЗ ИГРЫ\n" +
		"Silent Owl\n" +
		"Between August And December\n" +
		"\n" +
		"МУЗЫКА ИЗ ГЛАВНОГО МЕНЮ\n" +
		"For The Stars - Meet Me There\n" +
		"(Silent Owl cover)\n" +
		"\n" +
		"МУЗЫКА ИЗ ФИНАЛЬНЫХ ТИТРОВ\n" +
		"For The Stars - Road From Nowhere\n";
	public Color OnMouse;
	void Start () {
		thebackground = GameObject.FindGameObjectWithTag ("Background");
		oldBackground = GameObject.FindGameObjectWithTag ("oldBackground");
		LeftArrow = GameObject.FindGameObjectWithTag ("LeftArrow");
		RightArrow = GameObject.FindGameObjectWithTag ("RightArrow");
		SkipArrow = GameObject.FindGameObjectWithTag ("Skip");
		AutoButton = GameObject.FindGameObjectWithTag ("AutoCircle");
		//Background = thebackground.guiTexture.texture;
		Actor.gm = this;
		AudioStream.gm = this;
		stText = new StackText ();
		StandartColor = LeftArrow.guiTexture.color;
	}
	
	// Update is called once per frame
	void Update () {
		if ((PressLeft()) && (!BackMode))
		{
			targetText = "";
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

	static public IEnumerator PushText(string s)
	{
		int TextInterval = 0;
		CanDoNext = false;
		Text = "";
		Author = "";
		targetText = s;
		while (Text.Length<targetText.Length) {
			TextInterval++;
			if (TextInterval>=Settings.TextSpeed)
			{
				Text += targetText[Text.Length];
				TextInterval = 0;
			}
			if (((PressForward()) || (PressSkip())) && (Text.Length>1))
			{
				Text = targetText;
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
			yield return new WaitForSeconds(Settings.AutoTime + Text.Length*Settings.AutoMultiplier);
		CanDoNext = true;
	}
	
	static public IEnumerator PushText(string s, string a)
	{
		int TextInterval = 0;
		CanDoNext = false;
		Text = "";
		Author = a;
		targetText = s;
		while (Text.Length<targetText.Length) {
			TextInterval++;
			if (TextInterval>=Settings.TextSpeed)
			{
				Text += targetText[Text.Length];
				TextInterval = 0;
			}
			if (((PressForward()) || (PressSkip())) && (Text.Length>1))
			{
				Text = targetText;
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
			yield return new WaitForSeconds(Settings.AutoTime + Text.Length*Settings.AutoMultiplier);
		CanDoNext = true;
	}

	static public IEnumerator ChangeBackground(string path)
	{

		CanDoNext = false;
		oldBackground.guiTexture.color = thebackground.guiTexture.color;
		oldBackground.guiTexture.texture = thebackground.guiTexture.texture;
		thebackground.guiTexture.texture = Resources.Load<Texture>(BackgroundPath + path);
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

	static public void DefaultBackground(string path)
	{
		thebackground.guiTexture.texture = Resources.Load<Texture>(BackgroundPath + path);
		oldBackground.guiTexture.color = new Color (0, 0, 0, 0);
	}

	static public IEnumerator Titres(string initialBackground)
	{
		AudioStream Music = new AudioStream ("Sounds/Music/", false, Settings.MusicOn.GetHashCode ());
		Music.Play ("Road From Nowhere");
		float TextMoveSpeed = 0.001f;
		float TimeToShow = 3;
		float fontSizeMulitplier = 0.15f;
		GameObject obj = GameObject.FindGameObjectWithTag("Titres");
		CanDoNext = false;
		Text = "";
		Author = "";
		GameObject TitBack = new GameObject ("titback", typeof(GUITexture));
		TitBack.guiTexture.texture = Resources.Load<Texture>(BackgroundPath + initialBackground);
		TitBack.transform.position = new Vector3 (0.5f, 0.5f, 14);
		TitBack.transform.localScale = new Vector3 (1, 1, 0);
		TitBack.guiTexture.color = new Color (0, 0, 0, 0);
		while (TitBack.guiTexture.color.a<1)
		{
			TitBack.guiTexture.color += new Color(0,0,0,FadeSpeed);
			yield return null;
		}
		obj.guiText.text = titresText;
		thebackground.guiTexture.texture = Resources.Load<Texture>(BackgroundPath + initialBackground);
		while (obj.guiText.GetScreenRect().min.y<Screen.height)
		{
			obj.transform.position += new Vector3(0, TextMoveSpeed, 0);
			yield return null;
		}
		GameObject DayText = new GameObject ("daytext", typeof(GUIText));
		DayText.guiText.font = Resources.Load<Font>("Fonts/RODCHENKOC");
		DayText.guiText.color = new Color (1, 1, 1, 0);
		DayText.transform.position = new Vector3 (0.5f, 0.5f, 16);
		DayText.guiText.alignment = TextAlignment.Center;
		DayText.guiText.anchor = TextAnchor.MiddleCenter;
		DayText.guiText.fontStyle = FontStyle.Bold;
		DayText.guiText.fontSize = (int)(Screen.height * fontSizeMulitplier);
		DayText.guiText.text = "К О Н Е Ц";
		while (DayText.guiText.color.a<1)
		{
			DayText.guiText.color += new Color(0,0,0,FadeSpeed);
			yield return null;
		}
		yield return new WaitForSeconds(TimeToShow);
		Music.Stop ();
		while (DayText.guiText.color.a>0)
		{
			DayText.guiText.color -= new Color(0,0,0,FadeSpeed);
			yield return null;
		}
		while (TitBack.guiTexture.color.a>0)
		{
			TitBack.guiTexture.color -= new Color(0,0,0,FadeSpeed);
			yield return null;
		}
		CanDoNext = true;
		Destroy (TitBack);
		Destroy (DayText);
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
		DayText.guiText.font = Resources.Load<Font>("Fonts/RODCHENKOC");
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
		thebackground.guiTexture.texture = Resources.Load<Texture>(BackgroundPath + initialBackground);
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
		Destroy (DayBack);
		Destroy (DayText);
	}

	static public IEnumerator Flashing()
	{
		float FlashSpeed = 0.01f;
		if (PressSkip ())
			FlashSpeed = 0.05f;
		CanDoNext = false;
		oldBackground.guiTexture.color = new Color (0, 0, 0, 0);
		while (oldBackground.guiTexture.color.a<0.5f) 
		{
			oldBackground.guiTexture.color += new Color(0,0,0,FlashSpeed);
			yield return null;
		}
		oldBackground.guiTexture.color = new Color (0, 0, 0, 0.5f);
		yield return null;
		while (oldBackground.guiTexture.color.a > 0) 
		{
			oldBackground.guiTexture.color -= new Color(0,0,0,FlashSpeed);
			yield return null;
		}
		CanDoNext = true;
	}

	static public IEnumerator Flashing(string back)
	{
		float FlashSpeed = 0.01f;
		if (PressSkip ())
			FlashSpeed = 0.05f;
		CanDoNext = false;
		oldBackground.guiTexture.color = new Color (0, 0, 0, 0);
		while (oldBackground.guiTexture.color.a<0.5f) 
		{
			oldBackground.guiTexture.color += new Color(0,0,0,FlashSpeed);
			yield return null;
		}
		oldBackground.guiTexture.color = new Color (0, 0, 0, 0.5f);
		thebackground.guiTexture.texture = Resources.Load<Texture> (BackgroundPath + back);
		yield return null;
		while (oldBackground.guiTexture.color.a > 0) 
		{
			oldBackground.guiTexture.color -= new Color(0,0,0,FlashSpeed);
			yield return null;
		}
		CanDoNext = true;
	}

	static public IEnumerator FadeOut()
	{
		float WaitTime = 0f;
		CanDoNext = false;
		Text = "";
		Author = "";
		GameObject DayBack = new GameObject("dayback",typeof(GUITexture));
		DayBack.guiTexture.texture = thebackground.guiTexture.texture;
		DayBack.transform.position = new Vector3 (0.5f, 0.5f, 15);
		DayBack.transform.localScale = new Vector3 (1, 1, 0);
		DayBack.guiTexture.color = new Color (0, 0, 0, 0);
		while (DayBack.guiTexture.color.a<1)
		{
			DayBack.guiTexture.color += new Color(0,0,0,FadeSpeed/5);
			yield return null;
		}
		yield return new WaitForSeconds (WaitTime);
		CanDoNext = true;
	}

	static public bool PressForward()
	{
		if ((Input.GetKeyDown (KeyCode.Space)) || (Input.GetKeyDown(KeyCode.Return)) || (Click.RandomClick()) || ((PressRight()) && (!BackMode)))
			return true;
		return false;
	}

	static public bool PressLeft()
	{
		if ((Input.GetKeyDown(KeyCode.LeftArrow)) || (Click.OnClick(LeftArrow.guiTexture)) || (Input.GetAxis("Mouse ScrollWheel")>0))
		    return true;
		return false;
	}

	static public bool PressRight()
	{
		if ((Input.GetKeyDown(KeyCode.RightArrow)) || (Click.OnClick(RightArrow.guiTexture)) || (Input.GetAxis("Mouse ScrollWheel")<0))
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

	private void DependOnMouse(GameObject target)
	{
		if (Click.MouseOver(target.guiTexture))
			target.guiTexture.color = OnMouse;
		else
			target.guiTexture.color = StandartColor;
	}
}
