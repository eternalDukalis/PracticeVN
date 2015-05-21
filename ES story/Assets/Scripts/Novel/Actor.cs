using UnityEngine;
using System.Collections;

public class Actor {
	public string Name;
	public enum Side { Left, Right, Center};
	public float Height = 1.25f;
	static public float MoveSpeed = 0.025f;
	static public float ColorChangeSpeed = 0.025f;

	public struct Emotion { public string Name; public string Path; };
	public struct Body { public string BodyPath; public Emotion[] Emotions; };
	public Body[] Sprites;

	private GameObject MainSprite;
	private GameObject EmotionSprite;
	private string CurrentSprite;
	private string CurrentEmotion;
	private bool isActive = false;
	static public GameManaging gm;

	public Actor()
	{
		Name = "Default";
	}

	public Actor(string name, string path)
	{
		Name = name;
		LoadSprites (path);
		CurrentSprite = Sprites [0].BodyPath;
		CurrentEmotion = Sprites [0].Emotions [0].Path;
	}

	public void ChangeSprite (string title)
	{
		for (int i=0; i<Sprites.Length; i++)
		{
			for (int j=0; j<Sprites[i].Emotions.Length; j++)
			{
				if (Sprites[i].Emotions[j].Name==title)
				{
					CurrentSprite = Sprites[i].BodyPath;
					CurrentEmotion = Sprites[i].Emotions[j].Path;
					if (isActive)
					{
						MainSprite.guiTexture.texture = Resources.LoadAssetAtPath<Texture> (CurrentSprite);
						EmotionSprite.guiTexture.texture = Resources.LoadAssetAtPath<Texture> (CurrentEmotion);
					}
					return;
				}
			}
		}
	}
	
	public void SetSprite(Side position)
	{
		gm.StartCoroutine (setSprite (position));
	}
	
	public void SetSprite(Side position, Side appearanceSide)
	{
		gm.StartCoroutine (setSprite (position,appearanceSide));
	}
	
	public void Delete()
	{
		gm.StartCoroutine (delete ());
	}
	
	public void Delete(Side disappearanceSide)
	{
		gm.StartCoroutine (delete (disappearanceSide));
	}
	
	public void ChangePosition(Side targetPosition)
	{
		gm.StartCoroutine (changePosition (targetPosition));
	}
	
	private IEnumerator setSprite(Side position)
	{
		MonoBehaviour.Destroy (MainSprite);
		MainSprite = new GameObject(string.Format("{0}_main",Name),typeof(GUITexture));
		EmotionSprite = new GameObject(string.Format("{0}_emotion",Name),typeof(GUITexture));
		EmotionSprite.transform.parent = MainSprite.transform;
		isActive = true;
		MainSprite.guiTexture.color = new Color (0.5f, 0.5f, 0.5f, 0);
		EmotionSprite.guiTexture.color = new Color (0.5f, 0.5f, 0.5f, 0);
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
		MainSprite.guiTexture.texture = Resources.LoadAssetAtPath<Texture> (CurrentSprite);
		EmotionSprite.guiTexture.texture = Resources.LoadAssetAtPath<Texture> (CurrentEmotion);
		EmotionSprite.transform.position += new Vector3 (0, 0.5f-(float)MainSprite.guiTexture.texture.width/2/MainSprite.guiTexture.texture.height, 0.25f);
		MainSprite.transform.localScale = new Vector3 (Height*MainSprite.guiTexture.texture.width*Screen.height/MainSprite.guiTexture.texture.height/Screen.width, Height, 0);
		EmotionSprite.transform.localScale = new Vector3 (1, (float)MainSprite.guiTexture.texture.width/MainSprite.guiTexture.texture.height, 0);
		while (MainSprite.guiTexture.color.a<0.5f) {
			MainSprite.guiTexture.color += new Color(0,0,0,ColorChangeSpeed);
			EmotionSprite.guiTexture.color += new Color(0,0,0,ColorChangeSpeed);
			yield return null;
		}
		yield return null;
	}
	
	private IEnumerator setSprite(Side position, Side appearanceSide)
	{
		MonoBehaviour.Destroy (MainSprite);
		MainSprite = new GameObject(string.Format("{0}_main",Name),typeof(GUITexture));
		EmotionSprite = new GameObject(string.Format("{0}_emotion",Name),typeof(GUITexture));
		EmotionSprite.transform.parent = MainSprite.transform;
		isActive = true;
		MainSprite.guiTexture.color = new Color (0.5f, 0.5f, 0.5f, 0.5f);
		EmotionSprite.guiTexture.color = new Color (0.5f, 0.5f, 0.5f, 0.5f);
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
		MainSprite.guiTexture.texture = Resources.LoadAssetAtPath<Texture> (CurrentSprite);
		EmotionSprite.guiTexture.texture = Resources.LoadAssetAtPath<Texture> (CurrentEmotion);
		EmotionSprite.transform.position += new Vector3 (0, 0.5f-(float)MainSprite.guiTexture.texture.width/2/MainSprite.guiTexture.texture.height, 0.25f);
		MainSprite.transform.localScale = new Vector3 (Height*MainSprite.guiTexture.texture.width*Screen.height/MainSprite.guiTexture.texture.height/Screen.width, Height, 0);
		EmotionSprite.transform.localScale = new Vector3 (1, (float)MainSprite.guiTexture.texture.width/MainSprite.guiTexture.texture.height, 0);
		int Direction = 1;
		if (finalPosition < MainSprite.transform.position.x)
			Direction = -1;
		while (Mathf.Abs(finalPosition-MainSprite.transform.position.x)>MoveSpeed) {
			MainSprite.transform.position += new Vector3(Direction*MoveSpeed,0,0);
			yield return null;
		}
	}
	
	private IEnumerator delete()
	{
		if (isActive) {
			while (MainSprite.guiTexture.color.a>0) {
				MainSprite.guiTexture.color -= new Color(0,0,0,ColorChangeSpeed);
				EmotionSprite.guiTexture.color -= new Color(0,0,0,ColorChangeSpeed);
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
			int Direction = 1;
			if (finalPosition < MainSprite.transform.position.x)
				Direction = -1;
			while (Mathf.Abs(finalPosition-MainSprite.transform.position.x)>MoveSpeed) {
				MainSprite.transform.position += new Vector3(Direction*MoveSpeed,0,0);
				yield return null;
			}
			MonoBehaviour.Destroy (MainSprite);
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
		int Direction = 1;
		if (finalPosition < MainSprite.transform.position.x)
			Direction = -1;
		while (Mathf.Abs(finalPosition-MainSprite.transform.position.x)>MoveSpeed) {
			MainSprite.transform.position += new Vector3(Direction*MoveSpeed,0,0);
			yield return null;
		}
	}

	private void LoadSprites(string path)
	{
		int n = System.IO.Directory.GetFiles (path + "/Bodies","*.png").Length;
		Sprites = new Body[n];
		for (int i=1; i<=n; i++) 
		{
			Sprites[i-1].BodyPath = path+"/Bodies/"+i.ToString()+".png";
			string[] curemo = System.IO.Directory.GetFiles(path+"/Emotions",i.ToString()+"*.png");
			Sprites[i-1].Emotions = new Emotion[curemo.Length];
			for (int j=0; j<curemo.Length; j++)
			{
				Sprites[i-1].Emotions[j].Name = curemo[j].Remove(curemo[j].Length-4).Remove(0,(path+"Emotions/1").Length+1);
				Sprites[i-1].Emotions[j].Path = curemo[j];
			}
		}
	}
}
