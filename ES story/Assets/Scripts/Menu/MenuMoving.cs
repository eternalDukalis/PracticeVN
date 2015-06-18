using UnityEngine;
using System.Collections;

public class MenuMoving : MonoBehaviour {

	IEnumerator xmov;
	IEnumerator ymov;
	public float MoveSpeed;
	// Use this for initialization
	void Start () {
		xmov = XMoving (0);
		ymov = YMoving (0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void XMove(float target)
	{
		StopCoroutine (xmov);
		xmov = XMoving (target);
		StartCoroutine (xmov);
	}

	public void YMove(float target)
	{
		StopCoroutine (ymov);
		ymov = YMoving (target);
		StartCoroutine (ymov);
	}

	private IEnumerator XMoving(float target)
	{
		int Direction = 1;
		if (this.transform.position.x>target)
			Direction = -1;
		while ((this.transform.position.x<target-Direction*MoveSpeed)==(Direction==1))
		{
			this.transform.position += new Vector3(Direction*MoveSpeed,0,0);
			yield return null;
		}
		this.transform.position = new Vector3 (target, this.transform.position.y, this.transform.position.z);
	}

	private IEnumerator YMoving(float target)
	{
		int Direction = 1;
		if (this.transform.position.y>target)
			Direction = -1;
		while ((this.transform.position.y<target-Direction*MoveSpeed)==(Direction==1))
		{
			this.transform.position += new Vector3(0,Direction*MoveSpeed,0);
			yield return null;
		}
		this.transform.position = new Vector3 (this.transform.position.x, target, this.transform.position.z);
	}
}
