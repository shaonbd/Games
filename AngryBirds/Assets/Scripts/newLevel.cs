using UnityEngine;
using System.Collections;

public class newLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) && gameObject.guiText.enabled)
		{
			Application.LoadLevel("game");
		}
	}
}
