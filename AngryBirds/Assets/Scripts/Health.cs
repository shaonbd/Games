using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health = 35;
	private float _health;
	public AudioClip woodCrack;

	// Use this for initialization
	void Start () {
		_health = health;

	}
	


	void OnCollisionEnter2D(Collision2D C)
	{
		_health = _health - C.relativeVelocity.magnitude;
		GetComponent<Animator>().SetFloat("health",_health/health);

		if(C.relativeVelocity.magnitude > 3)
		{
			AudioSource.PlayClipAtPoint(woodCrack,Vector3.zero);
		}


	}
}
