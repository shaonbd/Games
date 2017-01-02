using UnityEngine;
using System.Collections;

public class SystemAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			Time.timeScale = 1;
			Destroy(gameObject);
		}
	}
}
