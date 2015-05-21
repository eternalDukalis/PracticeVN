using UnityEngine;
using System.Collections;

public class Scenario : MonoBehaviour {

	private bool EndOf = false;

	//Backgrounds
	private string Boathouse_night = "Assets/Graphics/Backgrounds/ext_boathouse_night.jpg";
	private string Stars = "Assets/Graphics/Backgrounds/stars.jpg";

	//Actors
	Actor Alice;
	void Start () {
		Alice = new Actor ("Алиса","Assets/Graphics/Sprites/dv");
	}

	IEnumerator TheScene()
	{
		PushText ("Звёзды..."); yield return StartCoroutine (WaitNext ());
		PushText ("Интересно, сколько же, в конце концов, звёзд мерцают на нашем небосклоне, волей или неволей заставляя людей погружаться в собственные мысли или просто глупо глазеть наверх? "); yield return StartCoroutine (WaitNext ());
		PushText ("Каждый, кто самостоятельно пытался узнать ответ на этот вопрос, неизбежно терпел неудачу, и это каждый знает. "); yield return StartCoroutine (WaitNext ());
		PushText ("Так почему же…"); yield return StartCoroutine (WaitNext ());
		PushText ("Семьдесят два","Семён"); yield return StartCoroutine (WaitNext ());
		PushText ("И вроде бы просто огромные газовые шары, а иногда кажутся живыми…"); yield return StartCoroutine (WaitNext ());
		PushText ("Семьдесят три","Семён"); yield return StartCoroutine (WaitNext ());
		PushText ("Может, я просто схожу с ума, но они даже вроде иногда подмигивают мне, словно зовут уютно расположиться среди них"); yield return StartCoroutine (WaitNext ());
		PushText ("Семьдесят четыре", "Семён"); yield return StartCoroutine (WaitNext ());
		PushText ("Я, может, и сам бы рад, но вот только…"); yield return StartCoroutine (WaitNext ());
		PushText ("И чем это тут мы занимаемся?","Алиса"); yield return StartCoroutine (WaitNext ());
		ChangeBackground (Boathouse_night); yield return StartCoroutine (WaitNext ());
		Alice.SetSprite (Actor.Side.Right);
		Alice.ChangeSprite ("smile");
	}

	// Update is called once per frame
	void Update () {
		if (!EndOf) {
			StartCoroutine(TheScene());
			EndOf = true;
		}
	}

	void PushText(string text)
	{
		StartCoroutine (GameManaging.PushText (text));
	}
	
	void PushText(string text, string author)
	{
		StartCoroutine (GameManaging.PushText (text,author));
	}

	void ChangeBackground(string path)
	{
		StartCoroutine (GameManaging.ChangeBackground (path));
	}

	IEnumerator WaitNext()
	{
		while (!GameManaging.CanDoNext) {
			yield return null;
		}
	}
}
