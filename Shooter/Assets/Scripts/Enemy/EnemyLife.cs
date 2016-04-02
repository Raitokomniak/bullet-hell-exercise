using UnityEngine;
using System.Collections;

public class EnemyLife : MonoBehaviour {

	float maxHealth;
	float currentHealth;

	// Use this for initialization
	void Start () {
		maxHealth = 2;
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if(currentHealth <= 0)
		{
			Destroy(this.gameObject);
		}
	}

	public void TakeHit(int damage)
	{
		currentHealth -= damage;
	}
}
