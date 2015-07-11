using UnityEngine;
using System.Collections;

public class BeginDay : MonoBehaviour {

	public int DayNum;
	public Color UnavailableColor;
	bool CanClick = true;
	bool NeedInit = true;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (NeedInit)
			Init ();
		if ((CanClick) && (Click.OnClick(this.guiText)))
		{
			Scenario.CurrentLevel = DayNum;
			LoadScreen scr = GameObject.FindObjectOfType<LoadScreen>();
			scr.MakeVisible();
			Application.LoadLevel("game");
		}
	}

	void Init()
	{
		//Debug.Log ("beg "+Scenario.MaxLevel+" ||| "+DayNum);
		if (DayNum>Scenario.MaxLevel)
		{
			this.guiText.color = UnavailableColor;
			CanClick = false;
		}
		NeedInit = false;
	}
}
