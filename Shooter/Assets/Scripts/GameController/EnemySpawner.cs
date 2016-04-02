using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	UIController ui;
	float levelTime;

	float levelTimer;

	Vector3 spawnPosition;

	bool[] spawnedWaves;
	int[] enemiesInWave;
	float enemyCounter;
	bool spawned;
	float spawnDelay;

	// Use this for initialization
	void Start () {
		levelTime = 20f;
		ui = GetComponent<UIController>();
		levelTimer = levelTime;
		spawnPosition = new Vector3(-7f, 12f, 0);
		spawned = false;
		spawnedWaves = new bool[1];
		enemiesInWave = new int[1];
		spawnDelay = 1;
		enemiesInWave[0] = 5;
		enemyCounter = 0;

	}
	
	// Update is called once per frame
	void Update () {
		UpdateTimer();

		if(levelTimer <= 18 && !spawnedWaves[0])
		{
			SpawnWave();
			spawnedWaves[0] = true;
		}

		if(spawnDelay > 0 && spawnedWaves[0] == true)
		{
			spawnDelay -= Time.deltaTime;
		}
		if(spawnDelay <= 0)
		{
			spawned = false;
			SpawnWave();
			spawnDelay = 1;
		}
	}
		

	void SpawnWave()
	{
		if(!spawned && enemyCounter < enemiesInWave[0])
		{
			enemyCounter += 1;
			Instantiate(Resources.Load("Enemy"), spawnPosition, transform.rotation);
			spawned = true;
		}
	}


	void UpdateTimer()
	{
		if(levelTimer > 0)
		{
			levelTimer -= Time.deltaTime;
		}

		ui.levelTimerValue = levelTimer;
	}


}
