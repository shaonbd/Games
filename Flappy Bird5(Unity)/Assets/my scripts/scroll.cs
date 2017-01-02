using UnityEngine;
using System.Collections;

public class scroll : MonoBehaviour {

	Vector3 initPos;
	// Use this for initialization
	void Start () {
		initPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-2*Time.deltaTime,0,0);

		if(transform.position.x <= -2)
		{
			transform.position = initPos;
		}
	}
}
