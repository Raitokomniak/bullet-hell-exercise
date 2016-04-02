using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	Rigidbody2D rb;

	float horizontalSpeed;
	float verticalSpeed;

	float waveTimer;

	float[] waves;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D>();
		horizontalSpeed = 2f;
		verticalSpeed = .5f;
		waveTimer = 0;
		rb.velocity = new Vector2(horizontalSpeed / 2, -verticalSpeed / 2);

		waves = new float[1];
	}
	
	// Update is called once per frame
	void Update () {
		waveTimer += Time.deltaTime;


		Move(1);

		if(transform.position.y < -12)
		{
			Destroy(this.gameObject);
		}
	}

	void Move(int pattern)
	{		
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
		}
	}
}
