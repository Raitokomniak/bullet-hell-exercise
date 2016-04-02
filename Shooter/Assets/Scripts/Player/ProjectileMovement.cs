using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour {

	int damage; //siirrä tämä hahmon statsitietoihin sitten

	float movementSpeed;
	GameObject PlayAreaTopWall;
	GameObject Enemy;

	// Use this for initialization
	void Awake() {
		damage = 1; //siirrä tämä hahmon statsitietoihin sitten

		movementSpeed = .5f;
		PlayAreaTopWall = GameObject.Find("PlayAreaTopWall");
		Enemy = GameObject.Find("Enemy");
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < PlayAreaTopWall.transform.position.y)
		{
		transform.position += new Vector3(0, movementSpeed, 0);
		}
		else if(transform.position.y >= PlayAreaTopWall.transform.position.y){
			Destroy(this.gameObject);
		}
			
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if(c.gameObject.tag == "Enemy")
		{
			c.gameObject.GetComponent<EnemyLife>().TakeHit(damage);
			Destroy(this.gameObject);
		}
	}
}
