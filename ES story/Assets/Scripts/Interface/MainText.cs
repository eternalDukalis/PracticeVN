using UnityEngine;
using System.Collections;

public class MainText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		this.guiText.text = GameManaging.Text;
	}
}
