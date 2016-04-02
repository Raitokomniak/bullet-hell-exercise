using UnityEngine;
using System.Collections;

public class EnemyProjectileMovement : MonoBehaviour {

	int damage; //siirrä tämä enemyn statsitietoihin sitten

	float movementSpeed;
	GameObject PlayAreaLeftWall;
	GameObject PlayAreaRightWall;
	GameObject PlayAreaTopWall;
	GameObject PlayAreaBottomWall;
	GameObject Player;

	Vector3 movementDirection;
	Vector3 initialPosition;

	// Use this for initialization
	void Awake() {
		damage = 1; //siirrä tämä enemyn statsitietoihin sitten

		movementSpeed = .5f;
		PlayAreaLeftWall = GameObject.Find("PlayAreaLeftWall");
		PlayAreaRightWall = GameObject.Find("PlayAreaRightWall");
		PlayAreaTopWall = GameObject.Find("PlayAreaTopWall");
		PlayAreaBottomWall = GameObject.Find("PlayAreaBottomWall");
		Player = GameObject.Find("Player");
		initialPosition = transform.position;
		movementDirection = Player.transform.position - initialPosition;

	}

	// Update is called once per frame
	void Update () {
		if(transform.position.y > PlayAreaBottomWall.transform.position.y)
		{
			Move();
			//Vector3.MoveTowards(transform.position, movementDirection, movementSpeed * Time.deltaTime);
			//transform.position -= new Vector3(0, movementSpeed, 0);
		}
		else if(transform.position.y <= PlayAreaBottomWall.transform.position.y){
			Destroy(this.gameObject);
		}
		else if(transform.position.x <= PlayAreaLeftWall.transform.position.x){
			Destroy(this.gameObject);
		}
		else if(transform.position.x >= PlayAreaRightWall.transform.position.x){
			Destroy(this.gameObject);
		}
		else if(transform.position.y >= PlayAreaTopWall.transform.position.x){
			Destroy(this.gameObject);
		}

	}

	void Move()
	{
		transform.Translate(movementDirection * (Time.deltaTime * movementSpeed));
		//transform.position = Vector3.MoveTowards(transform.position, movementDirection, movementSpeed * Time.deltaTime);

	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if(c.gameObject.tag == "Player")
		{
			Destroy(this.gameObject);
			Player.GetComponent<PlayerLife>().TakeHit();

		}
	}
}
