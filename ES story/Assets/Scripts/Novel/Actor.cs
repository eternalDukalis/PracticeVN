using UnityEngine;
using System.Collections;

public class Actor {
	public string Name;
	public enum Side { Left, Right, Center};
	public float Height = 1.5f;
	static public float SpeedStep = 0.6f;
	static public float FadeStep = 1.5f;
	static private float MoveSpeed = 0.6f;
	static private float ColorChangeSpeed = 1.5f;
	static public string LocalPath = "Graphics/Sprites/";
	
	private string apath;
	private GameObject MainSprite;
	private GameObject EmotionSprite;
	private bool isActive = false;
	private int Direction = 1;
	private IEnumerator PosCor;
	private IEnumerator FadeCor;
	static public GameManaging gm;
	public Actor()
	{
		Name = "Default";
	}

	public Actor(string name, string path)
	{
		Name = name;
		apath = path;
		PosCor = setSprite (Side.Center, "", Side.Center);
		FadeCor = setSprite (Side.Center, "");
	}

	public void ChangeSprite (string title)
	{
		MainSprite.GetComponent<GUITexture>().texture = Resources.Load<Texture>(LocalPath + apath + "/Bodies/" + title[0]);
		EmotionSprite.GetComponent<GUITexture>().texture = Resources.Load<Texture>(LocalPath + apath + "/Emotions/" + title);
	}
	
	public void SetSprite(Side position, string emotion)
	{
		if (GameManaging.PressSkip())
			ColorChangeSpeed = FadeStep*3;
		else
			ColorChangeSpeed = FadeStep;
		gm.StopCoroutine (PosCor);
		gm.StopCoroutine (FadeCor);
		FadeCor = setSprite (position, emotion);
		gm.StartCoroutine (FadeCor);
	}
	
	public void SetSprite(Side position, string emotion, Side appearanceSide)
	{
		if (GameManaging.PressSkip())
			MoveSpeed = SpeedStep*3;
		else
			MoveSpeed = SpeedStep;
		gm.StopCoroutine (PosCor);
		gm.StopCoroutine (FadeCor);
		PosCor = setSprite (position, emotion, appearanceSide);
		gm.StartCoroutine (PosCor);
	}
	
	public void Delete()
	{
		if (GameManaging.PressSkip())
			ColorChangeSpeed = FadeStep*3;
		else
			ColorChangeSpeed = FadeStep;
		//gm.StopCoroutine (PosCor);
		gm.StopCoroutine (FadeCor);
		FadeCor = delete ();
		gm.StartCoroutine (FadeCor);
	}
	
	public void Delete(Side disappearanceSide)
	{
		if (GameManaging.PressSkip())
			MoveSpeed = SpeedStep*3;
		else
			MoveSpeed = SpeedStep;
		EmotionSprite.transform.parent = null;
		MainSprite.transform.position += new Vector3 (0, 0, -2);
		EmotionSprite.transform.position += new Vector3 (0, 0, -1);
		gm.StopCoroutine (PosCor);
		//gm.StopCoroutine (FadeCor);
		PosCor = delete (disappearanceSide);
		gm.StartCoroutine (PosCor);
	}
	
	public void ChangePosition(Side targetPosition)
	{
		if (GameManaging.PressSkip())
			MoveSpeed = SpeedStep*3;
		else
			MoveSpeed = SpeedStep;
		gm.StopCoroutine (PosCor);
		//gm.StopCoroutine (FadeCor);
		PosCor = changePosition (targetPosition);
		gm.StartCoroutine (PosCor);
	}
	
	private IEnumerator setSprite(Side position, string emotion)
	{
		MonoBehaviour.Destroy (EmotionSprite);
		MonoBehaviour.Destroy (MainSprite);
		MainSprite = new GameObject(string.Format("{0}_main",Name),typeof(GUITexture));
		EmotionSprite = new GameObject(string.Format("{0}_emotion",Name),typeof(GUITexture));
		EmotionSprite.transform.parent = MainSprite.transform;
		isActive = true;
		MainSprite.GetComponent<GUITexture>().color = new Color (0.5f, 0.5f, 0.5f, 0);
		EmotionSprite.GetComponent<GUITexture>().color = new Color (0.5f, 0.5f, 0.5f, 0);
		switch (position)
		{
		case Side.Center:
			MainSprite.transform.position = new Vector3(0.5f,0.25f,0);
			break;
		case Side.Left:
			MainSprite.transform.position = new Vector3(0.2f,0.25f,0);
			break;
		case Side.Right:
			MainSprite.transform.position = new Vector3(0.8f,0.25f,0);
			break;
		}
		MainSprite.GetComponent<GUITexture>().texture = Resources.Load<Texture>(LocalPath + apath + "/Bodies/" + emotion[0]);
		EmotionSprite.GetComponent<GUITexture>().texture = Resources.Load<Texture>(LocalPath + apath + "/Emotions/" + emotion);
		/*Texture azaz = MainSprite.guiTexture.texture;
		azaz += EmotionSprite.guiTexture.texture;
		MainSprite.guiTexture.texture = azaz;*/
		EmotionSprite.transform.position += new Vector3 (0, 0.5f-(float)MainSprite.GetComponent<GUITexture>().texture.width/2/MainSprite.GetComponent<GUITexture>().texture.height, 0.25f);
		MainSprite.transform.localScale = new Vector3 (Height*MainSprite.GetComponent<GUITexture>().texture.width*Screen.height/MainSprite.GetComponent<GUITexture>().texture.height/Screen.width, Height, 0);
		EmotionSprite.transform.localScale = new Vector3 (1, (float)MainSprite.GetComponent<GUITexture>().texture.width/MainSprite.GetComponent<GUITexture>().texture.height, 0);
		while (MainSprite.GetComponent<GUITexture>().color.a<0.5f) {
			MainSprite.GetComponent<GUITexture>().color += new Color(0,0,0,ColorChangeSpeed*Time.deltaTime);
			EmotionSprite.GetComponent<GUITexture>().color += new Color(0,0,0,ColorChangeSpeed*Time.deltaTime);
			yield return null;
		}
		yield return null;
	}
	
	private IEnumerator setSprite(Side position, string emotion, Side appearanceSide)
	{
		MonoBehaviour.Destroy (EmotionSprite);
		MonoBehaviour.Destroy (MainSprite);
		MainSprite = new GameObject(string.Format("{0}_main",Name),typeof(GUITexture));
		EmotionSprite = new GameObject(string.Format("{0}_emotion",Name),typeof(GUITexture));
		EmotionSprite.transform.parent = MainSprite.transform;
		isActive = true;
		MainSprite.GetComponent<GUITexture>().color = new Color (0.5f, 0.5f, 0.5f, 0.5f);
		EmotionSprite.GetComponent<GUITexture>().color = new Color (0.5f, 0.5f, 0.5f, 0.5f);
		float finalPosition = 0;
		switch (position)
		{
		case Side.Center:
			finalPosition = 0.5f;
			break;
		case Side.Left:
			finalPosition = 0.2f;
			break;
		case Side.Right:
			finalPosition = 0.8f;
			break;
		}
		switch (appearanceSide)
		{
		case Side.Center:
			MainSprite.transform.position = new Vector3(0.5f,0.25f,0);
			break;
		case Side.Left:
			MainSprite.transform.position = new Vector3(-0.2f,0.25f,0);
			break;
		case Side.Right:
			MainSprite.transform.position = new Vector3(1.2f,0.25f,0);
			break;
		}
		MainSprite.GetComponent<GUITexture>().texture = Resources.Load<Texture>(LocalPath + apath + "/Bodies/" + emotion[0]);
		EmotionSprite.GetComponent<GUITexture>().texture = Resources.Load<Texture>(LocalPath + apath + "/Emotions/" + emotion);
		EmotionSprite.transform.position += new Vector3 (0, 0.5f-(float)MainSprite.GetComponent<GUITexture>().texture.width/2/MainSprite.GetComponent<GUITexture>().texture.height, 0.25f);
		MainSprite.transform.localScale = new Vector3 (Height*MainSprite.GetComponent<GUITexture>().texture.width*Screen.height/MainSprite.GetComponent<GUITexture>().texture.height/Screen.width, Height, 0);
		EmotionSprite.transform.localScale = new Vector3 (1, (float)MainSprite.GetComponent<GUITexture>().texture.width/MainSprite.GetComponent<GUITexture>().texture.height, 0);
		Direction = 1;
		if (finalPosition < MainSprite.transform.position.x)
			Direction = -1;
		while (Mathf.Abs(finalPosition-MainSprite.transform.position.x)>MoveSpeed*Time.deltaTime) {
			MainSprite.transform.position += new Vector3(Direction*MoveSpeed*Time.deltaTime,0,0);
			yield return null;
		}
	}
	
	private IEnumerator delete()
	{
		if (isActive) {
			while (MainSprite.GetComponent<GUITexture>().color.a>0) {
				MainSprite.GetComponent<GUITexture>().color -= new Color(0,0,0,ColorChangeSpeed*Time.deltaTime);
				EmotionSprite.GetComponent<GUITexture>().color -= new Color(0,0,0,ColorChangeSpeed*2*Time.deltaTime);
				yield return null;
			}
			MonoBehaviour.Destroy (MainSprite);
			isActive = false;
		}
	}
	
	private IEnumerator delete(Side disappearanceSide)
	{
		if (isActive) {
			float finalPosition = 0;
			switch (disappearanceSide)
			{
			case Side.Center:
				finalPosition = 0.5f;
				break;
			case Side.Left:
				finalPosition = -0.2f;
				break;
			case Side.Right:
				finalPosition = 1.2f;
				break;
			}
			Direction = 1;
			if (finalPosition < MainSprite.transform.position.x)
				Direction = -1;
			while (Mathf.Abs(finalPosition-MainSprite.transform.position.x)>MoveSpeed*Time.deltaTime) {
				MainSprite.transform.position += new Vector3(Direction*MoveSpeed*Time.deltaTime,0,0);
				EmotionSprite.transform.position += new Vector3(Direction*MoveSpeed*Time.deltaTime,0,0);
				yield return null;
			}
			MonoBehaviour.Destroy (MainSprite);
			MonoBehaviour.Destroy (EmotionSprite);
			isActive = false;
		}
	}
	
	private IEnumerator changePosition(Side targetPosition)
	{
		float finalPosition = 0;
		switch (targetPosition)
		{
		case Side.Center:
			finalPosition = 0.5f;
			break;
		case Side.Left:
			finalPosition = 0.2f;
			break;
		case Side.Right:
			finalPosition = 0.8f;
			break;
		}
		Direction = 1;
		if (finalPosition < MainSprite.transform.position.x)
			Direction = -1;
		while (Mathf.Abs(finalPosition-MainSprite.transform.position.x)>MoveSpeed*Time.deltaTime) {
			MainSprite.transform.position += new Vector3(Direction*MoveSpeed*Time.deltaTime,0,0);
			yield return null;
		}
	}
}
