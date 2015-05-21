using UnityEngine;
using System.Collections;

public class TextFit : MonoBehaviour {

	public float FontSize = 0.1f;
	// Use this for initialization
	void Start () {
		this.guiText.fontSize = (int)(FontSize * Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
