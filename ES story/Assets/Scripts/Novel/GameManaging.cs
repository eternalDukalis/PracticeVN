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
	static public GameObject TextForm;
	static GameManaging gm;
	static GameObject skp;
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
		"For The Stars - Road From Nowhere\n" +
		"\n" +
		"ТЕСТИРОВАНИЕ\n" +
		"god is my lover\n" +
		"rafffkaaa\n" +
		"\n" +
		"ДВИЖОК\n" +
		"Unity3D\n" +
		"\n" +
		"ГРУППА ВК\n" +
		"vk.com/dukalisgames\n";
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
		gm = this;
		stText = new StackText ();
		StandartColor = LeftArrow.GetComponent<GUITexture>().color;
		TextForm = GameObject.FindGameObjectWithTag ("TextForm");
		skp = GameObject.FindGameObjectWithTag ("SkipTitres");
		skp.SetActive (false);
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
		Text = "     ";
		int StartTextLength = Text.Length;
		Author = "";
		targetText = Text + s;
		while (Text.Length<targetText.Length) {
			TextInterval++;
			if (TextInterval>=Settings.TextSpeed)
			{
				Text += targetText[Text.Length];
				TextInterval = 0;
			}
			if (((PressForward()) || (PressSkip())) && (Text.Length>StartTextLength + 1))
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
			//yield return new WaitForSeconds(Settings.AutoTime + Text.Length*Settings.AutoMultiplier);
			yield return gm.StartCoroutine(WaitAuto(Text.Length));
		CanDoNext = true;
	}
	
	static public IEnumerator PushText(string s, string a)
	{
		int TextInterval = 0;
		CanDoNext = false;
		Text = "     ";
		int StartTextLength = Text.Length;
		Author = a;
		targetText = Text + s;
		while (Text.Length<targetText.Length) {
			TextInterval++;
			if (TextInterval>=Settings.TextSpeed)
			{
				Text += targetText[Text.Length];
				TextInterval = 0;
			}
			if (((PressForward()) || (PressSkip())) && (Text.Length>StartTextLength + 1))
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
			//yield return new WaitForSeconds(Settings.AutoTime + Text.Length*Settings.AutoMultiplier);
			yield return gm.StartCoroutine(WaitAuto(Text.Length));
		CanDoNext = true;
	}

	static public IEnumerator ChangeBackground(string path)
	{

		CanDoNext = false;
		oldBackground.GetComponent<GUITexture>().color = thebackground.GetComponent<GUITexture>().color;
		oldBackground.GetComponent<GUITexture>().texture = thebackground.GetComponent<GUITexture>().texture;
		thebackground.GetComponent<GUITexture>().texture = Resources.Load<Texture>(BackgroundPath + path);
		while (oldBackground.GetComponent<GUITexture>().color.a>=0) {
			if (((PressForward()) || (PressSkip())) && (oldBackground.GetComponent<GUITexture>().color.a<0.5f) && (!BackMode))
			{
				oldBackground.GetComponent<GUITexture>().color = new Color(0,0,0,0);
			}
			oldBackground.GetComponent<GUITexture>().color -= new Color(0,0,0,0.01f);
			yield return null;
		}
		CanDoNext = true;
	}

	static public void DefaultBackground(string path)
	{
		thebackground.GetComponent<GUITexture>().texture = Resources.Load<Texture>(BackgroundPath + path);
		oldBackground.GetComponent<GUITexture>().color = new Color (0, 0, 0, 0);
	}

	static public IEnumerator Titres(string initialBackground)
	{
		bool SkipThis = false;
		AudioStream Music = new AudioStream ("Sounds/Music/", false, Settings.MusicOn.GetHashCode ());
		Music.Play ("Road From Nowhere");
		float TextMoveSpeed = 0.00085f;
		float TimeToShow = 3;
		float fontSizeMulitplier = 0.15f;
		GameObject obj = GameObject.FindGameObjectWithTag("Titres");
		CanDoNext = false;
		Text = "";
		Author = "";
		GameObject TitBack = new GameObject ("titback", typeof(GUITexture));
		TitBack.GetComponent<GUITexture>().texture = Resources.Load<Texture>(BackgroundPath + initialBackground);
		TitBack.transform.position = new Vector3 (0.5f, 0.5f, 14);
		TitBack.transform.localScale = new Vector3 (1, 1, 0);
		TitBack.GetComponent<GUITexture>().color = new Color (0, 0, 0, 0);
		while (TitBack.GetComponent<GUITexture>().color.a<1)
		{
			TitBack.GetComponent<GUITexture>().color += new Color(0,0,0,FadeSpeed);
			yield return null;
		}
		skp.SetActive (true);
		obj.GetComponent<GUIText>().text = titresText;
		thebackground.GetComponent<GUITexture>().texture = Resources.Load<Texture>(BackgroundPath + initialBackground);
		while (obj.GetComponent<GUIText>().GetScreenRect().min.y<Screen.height)
		{
			obj.transform.position += new Vector3(0, TextMoveSpeed, 0);
			if (Click.OnClick(skp.GetComponent<GUITexture>()))
			{
				SkipThis = true;
				break;
			}
			yield return null;
		}
		if (SkipThis)
			Music.Stop();
		while ((SkipThis) && (obj.GetComponent<GUIText>().color.a>0))
		{
			obj.GetComponent<GUIText>().color -= new Color(0,0,0,FadeSpeed);
			yield return null;
		}
		while ((SkipThis) && (TitBack.GetComponent<GUITexture>().color.a>0))
		{
			TitBack.GetComponent<GUITexture>().color -= new Color(0,0,0,FadeSpeed);
			yield return null;
		}
		skp.SetActive (false);
		if (!SkipThis)
		{
			GameObject DayText = new GameObject ("daytext", typeof(GUIText));
			DayText.GetComponent<GUIText>().font = Resources.Load<Font>("Fonts/RODCHENKOC");
			DayText.GetComponent<GUIText>().color = new Color (1, 1, 1, 0);
			DayText.transform.position = new Vector3 (0.5f, 0.5f, 16);
			DayText.GetComponent<GUIText>().alignment = TextAlignment.Center;
			DayText.GetComponent<GUIText>().anchor = TextAnchor.MiddleCenter;
			DayText.GetComponent<GUIText>().fontStyle = FontStyle.Bold;
			DayText.GetComponent<GUIText>().fontSize = (int)(Screen.height * fontSizeMulitplier);
			DayText.GetComponent<GUIText>().text = "К О Н Е Ц";
			while (DayText.GetComponent<GUIText>().color.a<1)
			{
				DayText.GetComponent<GUIText>().color += new Color(0,0,0,FadeSpeed);
				yield return null;
			}
			yield return new WaitForSeconds(TimeToShow);
			Music.Stop ();
			while (DayText.GetComponent<GUIText>().color.a>0)
			{
				DayText.GetComponent<GUIText>().color -= new Color(0,0,0,FadeSpeed);
				yield return null;
			}
			while (TitBack.GetComponent<GUITexture>().color.a>0)
			{
				TitBack.GetComponent<GUITexture>().color -= new Color(0,0,0,FadeSpeed);
				yield return null;
			}
			Destroy (DayText);
		}
		CanDoNext = true;
		Destroy (TitBack);
	}

	static public IEnumerator ShowDay(string whattoshow, string initialBackground)
	{
		float TimeToShow = 3;
		float fontSizeMulitplier = 0.15f;
		CanDoNext = false;
		Text = "";
		Author = "";
		GameObject DayBack = new GameObject("dayback",typeof(GUITexture));
		DayBack.GetComponent<GUITexture>().texture = Resources.Load<Texture>(BackgroundPath + initialBackground);
		DayBack.transform.position = new Vector3 (0.5f, 0.5f, 15);
		DayBack.transform.localScale = new Vector3 (1, 1, 0);
		DayBack.GetComponent<GUITexture>().color = new Color (0, 0, 0, 0);
		while (DayBack.GetComponent<GUITexture>().color.a<1)
		{
			DayBack.GetComponent<GUITexture>().color += new Color(0,0,0,FadeSpeed);
			yield return null;
		}
		GameObject DayText = new GameObject ("daytext", typeof(GUIText));
		DayText.GetComponent<GUIText>().font = Resources.Load<Font>("Fonts/RODCHENKOC");
		DayText.GetComponent<GUIText>().color = new Color (1, 1, 1, 0);
		DayText.transform.position = new Vector3 (0.5f, 0.5f, 16);
		DayText.GetComponent<GUIText>().alignment = TextAlignment.Center;
		DayText.GetComponent<GUIText>().anchor = TextAnchor.MiddleCenter;
		DayText.GetComponent<GUIText>().fontStyle = FontStyle.Bold;
		DayText.GetComponent<GUIText>().fontSize = (int)(Screen.height * fontSizeMulitplier);
		DayText.GetComponent<GUIText>().text = whattoshow;
		while (DayText.GetComponent<GUIText>().color.a<1)
		{
			DayText.GetComponent<GUIText>().color += new Color(0,0,0,FadeSpeed);
			yield return null;
		}
		thebackground.GetComponent<GUITexture>().texture = Resources.Load<Texture>(BackgroundPath + initialBackground);
		yield return new WaitForSeconds(TimeToShow);
		while (DayText.GetComponent<GUIText>().color.a>0)
		{
			DayText.GetComponent<GUIText>().color -= new Color(0,0,0,FadeSpeed);
			yield return null;
		}
		while (DayBack.GetComponent<GUITexture>().color.a>0)
		{
			DayBack.GetComponent<GUITexture>().color -= new Color(0,0,0,FadeSpeed);
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
		oldBackground.GetComponent<GUITexture>().color = new Color (0, 0, 0, 0);
		while (oldBackground.GetComponent<GUITexture>().color.a<0.5f) 
		{
			oldBackground.GetComponent<GUITexture>().color += new Color(0,0,0,FlashSpeed);
			yield return null;
		}
		oldBackground.GetComponent<GUITexture>().color = new Color (0, 0, 0, 0.5f);
		yield return null;
		while (oldBackground.GetComponent<GUITexture>().color.a > 0) 
		{
			oldBackground.GetComponent<GUITexture>().color -= new Color(0,0,0,FlashSpeed);
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
		oldBackground.GetComponent<GUITexture>().color = new Color (0, 0, 0, 0);
		while (oldBackground.GetComponent<GUITexture>().color.a<0.5f) 
		{
			oldBackground.GetComponent<GUITexture>().color += new Color(0,0,0,FlashSpeed);
			yield return null;
		}
		oldBackground.GetComponent<GUITexture>().color = new Color (0, 0, 0, 0.5f);
		thebackground.GetComponent<GUITexture>().texture = Resources.Load<Texture> (BackgroundPath + back);
		yield return null;
		while (oldBackground.GetComponent<GUITexture>().color.a > 0) 
		{
			oldBackground.GetComponent<GUITexture>().color -= new Color(0,0,0,FlashSpeed);
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
		DayBack.GetComponent<GUITexture>().texture = thebackground.GetComponent<GUITexture>().texture;
		DayBack.transform.position = new Vector3 (0.5f, 0.5f, 15);
		DayBack.transform.localScale = new Vector3 (1, 1, 0);
		DayBack.GetComponent<GUITexture>().color = new Color (0, 0, 0, 0);
		while (DayBack.GetComponent<GUITexture>().color.a<1)
		{
			DayBack.GetComponent<GUITexture>().color += new Color(0,0,0,FadeSpeed/5);
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
		if ((Input.GetKeyDown(KeyCode.LeftArrow)) || (Click.OnClick(LeftArrow.GetComponent<GUITexture>())) || (Input.GetAxis("Mouse ScrollWheel")>0))
		    return true;
		return false;
	}

	static public bool PressRight()
	{
		if ((Input.GetKeyDown(KeyCode.RightArrow)) || (Click.OnClick(RightArrow.GetComponent<GUITexture>())) || (Input.GetAxis("Mouse ScrollWheel")<0))
			return true;
		return false;
	}

	static public bool PressSkip()
	{
		if ((Input.GetKey (KeyCode.LeftControl)) || (Click.OnPress(SkipArrow.GetComponent<GUITexture>())))
		{
			return true;
		}
		return false;
	}

	static public bool PressAuto()
	{
		if ((Input.GetKeyDown(KeyCode.A)) || (Click.OnClick(AutoButton.GetComponent<GUITexture>())))
			return true;
		return false;
	}

	private void DependOnMouse(GameObject target)
	{
		if (Click.MouseOver(target.GetComponent<GUITexture>()))
			target.GetComponent<GUITexture>().color = OnMouse;
		else
			target.GetComponent<GUITexture>().color = StandartColor;
	}

	static public void TextFormOn()
	{
		TextForm.SetActive (true);
	}

	static public void TextFormOff()
	{
		TextForm.SetActive (false);
	}

	static IEnumerator WaitAuto(int tlength)
	{
		int time = 0;
		while ((float)time/20<Settings.AutoTime + tlength*Settings.AutoMultiplier)
		{
			time++;
			if (((PressForward()) || (PressSkip()) || (PressAuto())) && (!BackMode))
				break;
			yield return null;
		}
	}
}
