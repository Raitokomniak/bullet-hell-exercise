using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	UIController ui;

	public int lives;
	public int xp;
	int xpCap;

	// Use this for initialization
	void Awake () {
		ui = GetComponent<UIController>();
		lives = 3;
		xpCap = 5;
		xp = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GainXP(int gainedXP)
	{
		xp += gainedXP;
		ui.UpdateXP(xp);
	}
}
