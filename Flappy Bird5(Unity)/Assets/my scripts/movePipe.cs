using UnityEngine;
using System.Collections;

public class movePipe : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 newPos = new Vector3(transform.position.x,Random.Range(-0.8828766f,2.370922f),0);
		transform.position = newPos;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-2*Time.deltaTime,0,0);

		if(transform.position.x <= -6)
		{
			Destroy(gameObject);
		}
	}
}
