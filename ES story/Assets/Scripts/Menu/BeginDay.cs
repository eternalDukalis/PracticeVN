﻿using UnityEngine;
using System.Collections;

public class BeginDay : MonoBehaviour {

	public int DayNum;
	public Color UnavailableColor;
	bool CanClick = true;
	// Use this for initialization
	void Start () {
		if (DayNum>Scenario.MaxLevel)
		{
			this.guiText.color = UnavailableColor;
			CanClick = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if ((CanClick) && (Click.OnClick(this.guiText)))
		{
			Scenario.CurrentLevel = DayNum;
			LoadScreen scr = GameObject.FindObjectOfType<LoadScreen>();
			scr.MakeVisible();
			Application.LoadLevel("game");
		}
	}
}