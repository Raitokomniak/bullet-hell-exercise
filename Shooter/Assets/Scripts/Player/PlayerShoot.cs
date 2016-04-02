using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	GameObject projectile;
	float coolDownTimer;
	float coolDown;

	// Use this for initialization
	void Awake () {
		projectile = Resources.Load("playerProjectile") as GameObject;
		coolDownTimer = 0f;
		coolDown = .2f;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.Space) && coolDownTimer <= 0)
		{
			Vector3 newPosition = transform.position + new Vector3(0, .5f, 0);
			GameObject.Instantiate(projectile, newPosition, transform.rotation);
			coolDownTimer = coolDown;
		}

		if(coolDownTimer > 0)
		{
			coolDownTimer -= Time.deltaTime;
		}

	}
}
