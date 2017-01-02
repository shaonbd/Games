using UnityEngine;
using System.Collections;

public class ThrowScript : MonoBehaviour {

	// Use this for initialization
	private Vector3 startPos;
	private Animator anim;
	private float strength;
	public LineRenderer line;


	public AudioClip birdCollide,birdFly, birdDie, slingShot, lose, win;


	bool mouseDrag;
	void Start () {
		GameObject.Find("TextResult").guiText.enabled = false;
		startPos = transform.position;
		startPos.z = 0;
		anim = gameObject.GetComponent<Animator>();
		mouseDrag = false;
		gameObject.rigidbody2D.isKinematic = true;
		line = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void OnMouseDown()
	{
		AudioSource.PlayClipAtPoint(slingShot,Vector3.zero);
	}

	void OnMouseDrag()
	{
		if(Time.timeScale == 0)
		{
			return;
		}
		mouseDrag = true;
		Vector3 b = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		b.z = 0;
		Vector3 a = startPos;		
		Vector3 ab = b-a;

		if(ab.sqrMagnitude <= 1)
		{
			strength = ab.sqrMagnitude;
			transform.position = new Vector3(b.x,b.y,0);

		}
		else
		{
			ab.Normalize();
			strength = ab.sqrMagnitude;
			transform.position = new Vector3(startPos.x + ab.x,startPos.y + ab.y,0);
		}
		line.SetPosition(0,transform.position);
		line.SetPosition(1,startPos);
		//Debug.Log(strength);

	}

	void BirdDeath()
	{
		rigidbody2D.isKinematic = true;
		anim.SetBool("death",true);

		Invoke("OnLose",2);
	}


	void OnLose()
	{
		GameObject[] pigs = GameObject.FindGameObjectsWithTag("Pig");
		if(pigs.Length != 0)
		{
			for(int i=0;i<pigs.Length;i++)
			{
				pigs[i].GetComponent<Animator>().SetBool("lose",true);
			}
			AudioSource.PlayClipAtPoint(lose,Vector3.zero);
			GameObject.Find("TextResult").guiText.text = "You Lose! Tap to try again!";
		}
		else
		{
			AudioSource.PlayClipAtPoint(win,Vector3.zero);
			GameObject.Find("TextResult").guiText.text = "You Win! Tap to try again!";
		}
		Destroy(gameObject);
		GameObject.Find("TextResult").guiText.enabled = true;
	}
	void OnMouseUp()
	{
		AudioSource.PlayClipAtPoint(birdFly,Vector3.zero);
		mouseDrag = false;
		if(strength <0.1)
		{
			transform.position = startPos;
		}
		else
		{
			gameObject.rigidbody2D.isKinematic = false;
			Vector2 t = new Vector2(startPos.x-transform.position.x,startPos.y-transform.position.y);
			
			t.Normalize();
		
			gameObject.rigidbody2D.velocity = t*strength*10;
		
			anim.SetBool("fly",true);
		}


	}

	void OnCollisionEnter2D(Collision2D c)
	{

		if( (c.relativeVelocity.magnitude > 5))
		{
		//	AudioSource.PlayClipAtPoint(birdCollide,Vector3.zero);
		}
		anim.SetBool("collide",true);	
		Invoke("BirdDeath",3);
	}

}
