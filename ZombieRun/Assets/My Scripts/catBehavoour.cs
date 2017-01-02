using UnityEngine;
using System.Collections;

public class catBehavoour : MonoBehaviour {

	Animator animator;
	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void deatryObjdect()
	{
		//Destroy(gameObject);
		Application.LoadLevel("menu");
	}

	void Death()
	{
		animator.SetBool("death",true);
	}

	void OnCollisionEnter2D( Collision2D c)
	{
		animator.SetBool("zombify",true);
		Invoke("Death",3);
	}
}
