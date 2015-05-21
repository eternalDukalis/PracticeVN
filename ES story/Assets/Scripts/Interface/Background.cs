using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
	
	void Start () 
	{
		this.transform.localScale = new Vector3 ((float)this.guiTexture.texture.width * Screen.height / this.guiTexture.texture.height / Screen.width, 1, 0);
	}

	void Update () 
	{
	
	}
}
