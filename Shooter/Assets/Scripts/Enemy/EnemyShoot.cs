using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {

	GameObject enemyProjectile;
	float coolDownTimer;
	float coolDown;

	// Use this for initialization
	void Awake () {
		enemyProjectile = Resources.Load("enemyProjectile") as GameObject;
		coolDown = 1f;
		coolDownTimer = 0;

	}

	// Update is called once per frame
	void Update () {

		if(coolDownTimer <= 0)
		{
			Vector3 newPosition = transform.position + new Vector3(0, -.5f, 0);
			GameObject.Instantiate(enemyProjectile, newPosition, transform.rotation);
			coolDownTimer = coolDown;
		}

		if(coolDownTimer > 0)
		{
			coolDownTimer -= Time.deltaTime;
		}

	}
}
