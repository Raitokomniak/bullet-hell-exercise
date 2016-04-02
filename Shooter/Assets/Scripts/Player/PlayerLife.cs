using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour {

	int lives;
	UIController ui;

	// Use this for initialization
	void Awake () {
		ui = GameObject.Find("GameController").GetComponent<UIController>();
		lives = 3;
		ui.livesValue = lives;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeHit()
	{
		if(lives > 0)
		{
		lives -= 1;
		ui.livesValue = lives;
		}
		else
		{
			SceneManager.LoadScene("Level1");
		}
	}
}
