using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
	
	void Start () 
	{
		this.transform.localScale = new Vector3 ((float)this.GetComponent<GUITexture>().texture.width * Screen.height / this.GetComponent<GUITexture>().texture.height / Screen.width, 1, 0);
	}

	void Update () 
	{
	
	}
}
