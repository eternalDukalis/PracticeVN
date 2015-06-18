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
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		this.guiText.text = GameManaging.Author;
		switch (GameManaging.Author) 
		{
		case "Алиса":
			this.guiText.color = AliceColor;
			break;
		case "Электроник":
			this.guiText.color = ElectronicColor;
			break;
		case "Мику":
			this.guiText.color = MikuColor;
			break;
		case "Ольга Дмитриевна":
			this.guiText.color = OlgaColor;
			break;
		case "Женя":
			this.guiText.color = ZhenyaColor;
			break;
		case "Шурик":
			this.guiText.color = ShurikColor;
			break;
		case "Славя":
			this.guiText.color = SlavyaColor;
			break;
		case "Лена":
			this.guiText.color = HelenColor;
			break;
		case "Ульяна":
			this.guiText.color = UlianaColor;
			break;
		case "Семён":
			this.guiText.color = SemyonColor;
			break;
		case "Санёк":
			this.guiText.color = SanyokColor;
			break;
		default:
			this.guiText.color = new Color(1,1,1,1);
			break;
		}
	}
}
