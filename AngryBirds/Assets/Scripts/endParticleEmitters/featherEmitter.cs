using UnityEngine;
using System.Collections;

public class featherEmitter : MonoBehaviour {

	private ParticleSystem p;
	// Use this for initialization

	void Start()
	{
		p = GameObject.Find("PS_Feathur").GetComponent<ParticleSystem>();
	}

	void OnBirdDeath()
	{

		Vector3 v = transform.position;
		v.z = 0;
		p.gameObject.transform.position = v;
		ParticleSystem p_ = Instantiate(p,v,Quaternion.identity) as ParticleSystem;
		p_.emissionRate = 0;
		p_.Emit(5);
		gameObject.collider2D.enabled = false;
		Destroy(p_,0.5f);	

		//Invoke ("disableCollider",1);
		//Destroy(gameObject,1);
	}
}
