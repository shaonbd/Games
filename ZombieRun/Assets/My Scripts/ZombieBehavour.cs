using UnityEngine;
using System.Collections;

public class ZombieBehavour : MonoBehaviour {

	public float moveSpeed, turnSpeed;
	private Vector3 targetPos, moveDirection;


	// Use this for initialization
	void Start () {
		//targetPos = transform.position;
		moveDirection = Vector3.right;

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) && pause.pressed == false)
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePos.z = 0;
			targetPos = mousePos;
			moveDirection = mousePos - transform.position;
			moveDirection.Normalize();

		}

		if(pause.pressed = true)
		{
			pause.pressed = false;
		}
		//transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * moveSpeed);
		transform.position = Vector3.Lerp(transform.position, transform.position + (moveDirection * moveSpeed),Time.deltaTime);

		float targerAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,0,targerAngle),Time.deltaTime*turnSpeed);

	}


	void Destroy()
	{
		Destroy(gameObject);
	}
	void OnCollisionEnter2D( Collision2D c)
	{
			moveDirection *= -1;
		
	}
}
