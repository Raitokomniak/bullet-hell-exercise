using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	PlayerStats stats;

	Text levelTimer;
	Text lives;
	Text xp;
	Text wave;

	public float levelTimerValue;

	// Use this for initialization
	void Start () {
		stats = GetComponent<PlayerStats>();

		levelTimer = GameObject.Find("levelTimer").GetComponent<Text>();
		lives = GameObject.Find("lives").GetComponent<Text>();
		xp = GameObject.Find("xp").GetComponent<Text>();
		wave = GameObject.Find("wave").GetComponent<Text>();

		UpdateLives(stats.lives);
	}
	
	// Update is called once per frame
	void Update () {
		levelTimer.text = levelTimerValue.ToString("F2");
	}

	public void UpdateXP(int updatedXP)
	{
		xp.text = updatedXP.ToString();
	}

	public void UpdateLives(int updatedLives)
	{
		lives.text = updatedLives.ToString();
	}

	public void UpdateWave(int updatedWave)
	{
		wave.text = updatedWave.ToString();
	}

		
}
