using UnityEngine;
using System.Collections;

public class pauseButton : MonoBehaviour {

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
		if(Time.timeScale != 0)
		{
			Time.timeScale =0;
		}
		else
		{
			Time.timeScale = 1;
		}
		pressed = true;
	}
}
