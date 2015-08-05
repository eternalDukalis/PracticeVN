using UnityEngine;
using System.Collections;

public class TextureFit : MonoBehaviour {

	public float Multiplier;
	// Use this for initialization
	void Start () {
		this.transform.localScale = new Vector3 (Multiplier*(float)Screen.height*this.GetComponent<GUITexture>().texture.width/this.GetComponent<GUITexture>().texture.height/Screen.width, this.transform.localScale.y, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
