using UnityEngine;
using System.Collections;

public class EnemyProjectileMovement : MonoBehaviour {

	int damage; //siirrä tämä enemyn statsitietoihin sitten

	float movementSpeed;
	GameObject PlayAreaBottomWall;
	GameObject Player;

	// Use this for initialization
	void Awake() {
		damage = 1; //siirrä tämä enemyn statsitietoihin sitten

		movementSpeed = .2f;
		PlayAreaBottomWall = GameObject.Find("PlayAreaBottomWall");
		Player = GameObject.Find("Player");
	}

	// Update is called once per frame
	void Update () {
		if(transform.position.y > PlayAreaBottomWall.transform.position.y)
		{
			transform.position -= new Vector3(0, movementSpeed, 0);
		}
		else if(transform.position.y <= PlayAreaBottomWall.transform.position.y){
			Destroy(this.gameObject);
		}

	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if(c.gameObject.tag == "Player")
		{
			Player.GetComponent<PlayerLife>().TakeHit();
			Destroy(this.gameObject);
		}
	}
}
