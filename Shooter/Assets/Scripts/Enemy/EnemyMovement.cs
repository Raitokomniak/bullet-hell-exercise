using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	EnemySpawner spawner;

	Rigidbody2D rb;

	float horizontalSpeed;
	float verticalSpeed;

	float waveTimer;

	float[] waves;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D>();
		spawner = GameObject.Find("GameController").GetComponent<EnemySpawner>();
		horizontalSpeed = 2f;
		verticalSpeed = .5f;
		waveTimer = 0;
		rb.velocity = new Vector2(horizontalSpeed / 2, -verticalSpeed / 2);
		waves = new float[3];
	}
	
	// Update is called once per frame
	void Update () {

		waveTimer += Time.deltaTime;

		if (spawner.currentWave == 3) Move(2);
		else Move(1);

		//Destroys enemy when out of bounds
		if(transform.position.y < -12 || transform.position.x < -19 || transform.position.x > 6 )
		{
			Destroy(this.gameObject);
		}

	}

	void Move(int pattern)
	{		

		//PATTERNS
		//
		//Pattern 1 - Enemies move zigzagging from top center to bottom
		//Pattern 2 - Enemies come from top right, slow down on center and speed across to the left side
		//

		switch(pattern) {
		case 1:
			if(waveTimer < 2)
			{
				rb.AddForce(new Vector2(horizontalSpeed, -verticalSpeed));
			}
			else if (waveTimer > 2 && waveTimer < 4)
			{
				horizontalSpeed = 5.1f;
				rb.AddForce(new Vector2(-horizontalSpeed, -verticalSpeed));
			}
			else if (waveTimer > 6 && waveTimer < 8)
			{
				rb.AddForce(new Vector2(horizontalSpeed, -verticalSpeed));
			}
			break;

		case 2:
			if(waveTimer < 1.5)
			{
				horizontalSpeed = 6f;
				rb.AddForce(new Vector2(-horizontalSpeed, 0));
			}
			else if (waveTimer > 1.5 && waveTimer < 3)
			{
				horizontalSpeed = 2f;
				rb.velocity = new Vector2(-horizontalSpeed, 0);
				//rb.AddForce(new Vector2(-horizontalSpeed, 0));
			}
			else if (waveTimer > 3 && waveTimer < 4.5)
			{
				horizontalSpeed = 3f;
				rb.AddForce(new Vector2(-horizontalSpeed, 0));
			}
			break;

		}
	}
}
