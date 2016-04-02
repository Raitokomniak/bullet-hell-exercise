using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	//UI for updating level, wave and timer data
	UIController ui;

	int currentLevel;
	public int currentWave;

	//Full level time and counting down timer
	float levelTime;
	float levelTimer;

	//Spawn position that's initialized according to wave pattern
	Vector3 spawnPosition;

	//Initialized according to wave
	bool[] spawnedWaves;
	int[] enemiesInWave;
	float[] waveSpawnTimes;
	float enemyCounter;

	//Variables for in-wave spawning
	bool spawned;
	float spawnDelay;



	void Start () {
		
		ui = GetComponent<UIController>();

		waveSpawnTimes = new float[10];
		spawnedWaves = new bool[10];
		enemiesInWave = new int[10];

		currentLevel = 1;

		InitializeLevel(currentLevel);
		InitializeWave();


	}
	
	// Update is called once per frame
	void Update () {

		UpdateTimer();
		UpdateSpawnDelay();

		if(levelTime - levelTimer > waveSpawnTimes[1] && !spawnedWaves[1])
		{
			ui.UpdateWave(currentWave);
			spawnPosition = new Vector3(-7f, 12f, 0);
			SpawnWave(currentWave);
			spawnedWaves[1] = true;
		}

		if(levelTime - levelTimer > waveSpawnTimes[2] && !spawnedWaves[2])
		{
			currentWave = 2;
			InitializeWave();
			ui.UpdateWave(currentWave);
			SpawnWave(currentWave);
			spawnedWaves[2] = true;
		}

		if(levelTime - levelTimer > waveSpawnTimes[3] && !spawnedWaves[3])
		{
			currentWave = 3;
			InitializeWave();
			ui.UpdateWave(currentWave);

			spawnPosition = new Vector3(5, 8f, 0);
			SpawnWave(currentWave);
			spawnedWaves[3] = true;
		}
	}
		

	//
	// Wave spawning
	//

	void SpawnWave(int currentWave)
	{
		switch(currentWave)
		{
		case 1:
			if(!spawned && enemyCounter < enemiesInWave[1]) {
				enemyCounter += 1;
				Instantiate(Resources.Load("Enemy"), spawnPosition, transform.rotation);
				spawned = true;
			}
				break;
		case 2:
			if(!spawned && enemyCounter < enemiesInWave[2]) {
				enemyCounter += 1;
				Instantiate(Resources.Load("Enemy"), spawnPosition, transform.rotation);
				spawned = true;
			}
			break;
		case 3:
			if(!spawned && enemyCounter < enemiesInWave[3]) {
				enemyCounter += 1;
				Instantiate(Resources.Load("Enemy"), spawnPosition, transform.rotation);
				spawned = true;
			}
			break;
		}
	}

	//
	//Initializing
	//

	void InitializeLevel(int currentLevel)
	{
		//These are always the same
		spawned = false;
		currentWave = 1;

		switch(currentLevel)
		{
		case 1:
			levelTime = 60f;
			levelTimer = levelTime;

			enemiesInWave[1] = 5;
			enemiesInWave[2] = 4;
			enemiesInWave[3] = 10;

			waveSpawnTimes[1] = 5;
			waveSpawnTimes[2] = 20;
			waveSpawnTimes[3] = 35;
			break;
		}
	}

	void InitializeWave()
	{
		enemyCounter = 0;
		spawnDelay = 1;
	}

	//
	//Updates to timers
	//

	void UpdateSpawnDelay()
	{
		if(spawnDelay > 0 && spawnedWaves[1] == true)
		{
			spawnDelay -= Time.deltaTime;
		}
		if(spawnDelay <= 0)
		{
			spawned = false;
			SpawnWave(currentWave);
			spawnDelay = 1;
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
