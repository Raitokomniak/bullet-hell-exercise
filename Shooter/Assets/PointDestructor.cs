using UnityEngine;
using System.Collections;

public class PointDestructor : MonoBehaviour {
	GameObject PlayAreaBottomWall;

	void Awake () {
		PlayAreaBottomWall = GameObject.Find("PlayAreaBottomWall");
	}

	void Update () {
		if(transform.position.y <= PlayAreaBottomWall.transform.position.y){
			Destroy(this.gameObject);
		}
	}


}
