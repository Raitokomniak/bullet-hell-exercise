using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour {

	PlayerStats stats;
	int lives;
	UIController ui;
	
	bool invulnerable;

	float invulnerableTimer;

	// Use this for initialization
	void Awake () {
		stats = GameObject.Find("GameController").GetComponent<PlayerStats>();
		ui = GameObject.Find("GameController").GetComponent<UIController>();
		lives = stats.lives;
		invulnerableTimer = 2f;

	}
	
	// Update is called once per frame
	void Update () {
		if(invulnerable)
		{
			invulnerableTimer -= Time.deltaTime;
			Invulnerable();
		}
	}


	void OnTriggerEnter2D(Collider2D c)
	{
		if(c.gameObject.tag == "ExpPoint")
		{
			stats.GainXP(1);
			Destroy(c.gameObject);
		}
		if(c.gameObject.tag == "Enemy")
		{
			TakeHit();
		}
	}

	public void TakeHit()
	{
		if(lives > 0 && !invulnerable)
		{
			lives -= 1;
			ui.UpdateLives(lives);
			invulnerable = true;
		}
		else if(lives <= 0)
		{
			SceneManager.LoadScene("Level1");
		}

	}

	void Invulnerable()
	{
		float t = invulnerableTimer; 
		if(t < 2.0 && t > 1.8 || 
		   t < 1.6 && t > 1.4 || 
		   t < 1.2 && t > 1.0 || 
		   t < 0.8 && t > 0.6 ||
		   t < 0.4 && t > 0.2) 
		{
		GetComponent<SpriteRenderer>().enabled = false;
		}
		else if(t < 1.8 && t > 1.6 || 
			    t < 1.4 && t > 1.2 || 
			    t < 1.0 && t > 0.8 || 
			    t < 0.6 && t > 0.4 ||
				t < 0.2 && t > 0.0)
		{
		GetComponent<SpriteRenderer>().enabled = true;
		}
		else if(t <= 0)
		{
			invulnerable = false;
			invulnerableTimer = 2;
		}
	}
}
