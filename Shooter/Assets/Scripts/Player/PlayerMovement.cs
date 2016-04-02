using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	float movementSpeed;
	GameObject PlayAreaLeftWall;
	GameObject PlayAreaRightWall;
	GameObject PlayAreaTopWall;
	GameObject PlayAreaBottomWall;

	// Use this for initialization
	void Awake () {
		movementSpeed = .2f;
		PlayAreaLeftWall = GameObject.Find("PlayAreaLeftWall");
		PlayAreaRightWall = GameObject.Find("PlayAreaRightWall");
		PlayAreaTopWall = GameObject.Find("PlayAreaTopWall");
		PlayAreaBottomWall = GameObject.Find("PlayAreaBottomWall");
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			if(transform.position.x > PlayAreaLeftWall.transform.position.x)
			{
			transform.position -= new Vector3(movementSpeed, 0, 0);
			}
		}

		if(Input.GetKey(KeyCode.RightArrow))
		{
			if(transform.position.x <= PlayAreaRightWall.transform.position.x)
			{
			transform.position += new Vector3(movementSpeed, 0, 0);
			}
		}

		if(Input.GetKey(KeyCode.UpArrow))
		{
			if(transform.position.y <= PlayAreaTopWall.transform.position.y)
			{
			transform.position += new Vector3(0, movementSpeed, 0);
			}
		}


		if(Input.GetKey(KeyCode.DownArrow))
		{
			if(transform.position.y >= PlayAreaBottomWall.transform.position.y)
			{
			transform.position -= new Vector3(0, movementSpeed, 0);
			}
		}
	}


}
