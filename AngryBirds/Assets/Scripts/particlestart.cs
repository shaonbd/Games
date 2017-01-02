using UnityEngine;
using System.Collections;

public class particlestart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.renderer.sortingLayerName = "particle";
		this.renderer.sortingOrder = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
