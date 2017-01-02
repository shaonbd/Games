using UnityEngine;
using System.Collections;

public class newPipw : MonoBehaviour {

	public GameObject pipeObject;
	// Use this for initialization
	void Start () {
		InvokeRepeating("makeNewPipe",2,2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void makeNewPipe()
	{
		Instantiate(pipeObject,new Vector3(4,0,0),Quaternion.identity);
	}
}
