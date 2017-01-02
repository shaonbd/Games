using UnityEngine;
using System.Collections;

public class PigHealth : MonoBehaviour {

	private float health ;
	private Animator anim;
	private float _health;
	public AudioClip hurt;

	// Use this for initialization
	void Start () {
		health = 10;
		anim = GetComponent<Animator>();
		_health = health;
	}



	/*float impactforce( )
	{
		var impactVelocityX = rigidbody.velocity.x - contact.otherCollider.rigidbody.velocity.x;
		impactVelocityX *= Mathf.Sign(impactVelocityX);
		var impactVelocityY = rigidbody.velocity.y - contact.otherCollider.rigidbody.velocity.y;
		impactVelocityY *= Mathf.Sign(impactVelocityY);
		var impactVelocity = impactVelocityX + impactVelocityY;
		var impactForce = impactVelocity * rigidbody.mass * contact.otherCollider.rigidbody.mass;
		impactForce *= Mathf.Sign(impactForce);
	}*/

	void OnPigDeath()
	{
		AudioSource.PlayClipAtPoint(hurt,Vector3.zero);
		Destroy(gameObject);
	}
	void OnCollisionEnter2D(Collision2D C)
	{
		//Vector3.Dot(C.contacts[0].normal,C.relativeVelocity) * rigidbody.mass
		//Vector2 r =  rigidbody2D.velocity - C.rigidbody.velocity;
		if(_health >0.1f)
		{
			_health = _health - C.relativeVelocity.magnitude;
			float k = _health/health;
			
			if(k < 0.7f)
			{
				
				anim.SetBool("hurt",true);
			}
			if(k < 0.1f)
			{
				anim.SetBool("death",true);
				AudioSource.PlayClipAtPoint(hurt,Vector3.zero);
			}

		}



	}
}
