using UnityEngine;
using System.Collections;

public class birdBehavour : MonoBehaviour {


	Vector3 velocity, rotation;
	int score;
	GUIText scoreText;
	public AudioClip pointSound;
	// Use this for initialization
	void Start () {
		velocity = new Vector3(0,7,0);
		score = 0;
		scoreText = GameObject.Find("scoreText").GetComponent<GUIText>();
		scoreText.text = "Score : "+ score;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) && pauseButton.pressed==false && Time.timeScale!=0)
		{
			rigidbody2D.velocity = velocity;
			transform.rotation = Quaternion.Euler(0,0,40);
		}

		if(pauseButton.pressed == true)
		{
			pauseButton.pressed = false;
		}
		transform.Rotate(new Vector3(0,0,-90 *  Time.deltaTime));
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		int best = PlayerPrefs.GetInt("best");
		if(score>best)
		{
			PlayerPrefs.SetInt("best",score);
			PlayerPrefs.Save();
		}
		Application.LoadLevel("menu");
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		score +=1;
		scoreText.text = "Score : "+ score;
		AudioSource.PlayClipAtPoint(pointSound,Vector3.zero);
		Destroy(c.gameObject);
	}
}
