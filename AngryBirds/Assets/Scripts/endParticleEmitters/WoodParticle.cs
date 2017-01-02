using UnityEngine;
using System.Collections;

public class WoodParticle : MonoBehaviour {

	// Use this for initialization
	private ParticleSystem p;

	void Start()
	{
		p = GameObject.Find("PS_Wood").GetComponent<ParticleSystem>();
	}



	void OnWoodEnd()
	{
		Vector3 v = transform.position;
		v.z = 0;
		p.gameObject.transform.position = v;
		ParticleSystem p_ = Instantiate(p,v,Quaternion.identity) as ParticleSystem;
		p_.emissionRate = 0;
		p_.Emit(10);
		Destroy(p_,0.5f);
		Destroy(gameObject);
	}
}
