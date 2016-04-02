using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	Text levelTimer;
	Text lives;
	public float levelTimerValue;
	public float livesValue;

	// Use this for initialization
	void Start () {
		levelTimer = GameObject.Find("levelTimer").GetComponent<Text>();
		lives = GameObject.Find("lives").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		levelTimer.text = levelTimerValue.ToString();
		lives.text = livesValue.ToString();
	}
		
}
