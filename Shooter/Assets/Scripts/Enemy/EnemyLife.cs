using UnityEngine;
using System.Collections;

public class EnemyLife : MonoBehaviour {

	GameObject GC;

	float maxHealth;
	float currentHealth;

	// Use this for initialization
	void Awake () {
		GC = GameObject.Find("GameController");
		maxHealth = 1;
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeHit(int damage)
	{
		currentHealth -= damage;

		if(currentHealth <= 0)
		{
			//GC.GetComponent<PlayerStats>().GainXP(1);
			Die();

		}
	}

	void Die()
	{
		Destroy(this.gameObject);
		Instantiate(Resources.Load("expPoint"), transform.position, transform.rotation);
	}
}
