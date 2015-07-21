using UnityEngine;
using System.Collections;

public class Author : MonoBehaviour {

	public Color AliceColor;
	public Color ElectronicColor;
	public Color MikuColor;
	public Color OlgaColor;
	public Color ZhenyaColor;
	public Color ShurikColor;
	public Color SlavyaColor;
	public Color HelenColor;
	public Color UlianaColor;
	public Color SemyonColor;
	public Color SanyokColor;
	Color CurrentColor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.guiText.text!=GameManaging.Author)
			this.guiText.text = GameManaging.Author;
		switch (GameManaging.Author) 
		{
		case "Алиса":
			CurrentColor = AliceColor;
			break;
		case "Электроник":
			CurrentColor = ElectronicColor;
			break;
		case "Мику":
			CurrentColor = MikuColor;
			break;
		case "Ольга Дмитриевна":
			CurrentColor = OlgaColor;
			break;
		case "Женя":
			CurrentColor = ZhenyaColor;
			break;
		case "Шурик":
			CurrentColor = ShurikColor;
			break;
		case "Славя":
			CurrentColor = SlavyaColor;
			break;
		case "Лена":
			CurrentColor = HelenColor;
			break;
		case "Ульяна":
			CurrentColor = UlianaColor;
			break;
		case "Семён":
			CurrentColor = SemyonColor;
			break;
		case "Санёк":
			CurrentColor = SanyokColor;
			break;
		default:
			CurrentColor = new Color(1,1,1,1);
			break;
		}
		if (this.guiText.color!=CurrentColor)
			this.guiText.color = CurrentColor;
	}
}
