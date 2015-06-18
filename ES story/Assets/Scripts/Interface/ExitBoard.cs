using UnityEngine;
using System.Collections;

public class ExitBoard : MonoBehaviour {

	static public bool isOnScreen = false;
	// Use this for initialization
	void Start () {
		Update ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((isOnScreen) && (this.transform.position.x > 1))
			this.transform.position = new Vector3 (this.transform.position.x - 1, this.transform.position.y, this.transform.position.z);
		if ((!isOnScreen) && (this.transform.position.x < 1))
			this.transform.position = new Vector3 (this.transform.position.x + 1, this.transform.position.y, this.transform.position.z);
	}
}
