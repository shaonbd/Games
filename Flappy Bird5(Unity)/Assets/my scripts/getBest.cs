using UnityEngine;
using System.Collections;

public class getBest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.guiText.text = "Best : "+ PlayerPrefs.GetInt("best");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
