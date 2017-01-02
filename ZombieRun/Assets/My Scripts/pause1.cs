using UnityEngine;
using System.Collections;

public class pause1 : MonoBehaviour {


	public static bool pressed;
	// Use this for initialization
	void Start () {
		pressed = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{
		Application.LoadLevel("menu");
	}
}
