﻿// Script by Yang Liu

using UnityEngine;
using System.Collections;

public class PlayerMovement: MonoBehaviour {

    public float moveSpeed = 50f;

	public string horizontalAxisName = "Horizontal";
	public string verticalAxisName = "Vertical";

	public enum Direction {NORTH, SOUTH, EAST, WEST};

	public Direction initialFacing = Direction.SOUTH;
	//public Transform playerFeet;

    Vector2 moveVector;
    Rigidbody2D myRigidbody;

	Vector2 lastDirection;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();

		lastDirection = DirectionToVector(initialFacing);

	}
	
	// Update is called once per frame
	void Update () {
		// get the axis values, construct a vector and normalize it
		float horizontal = Input.GetAxis (horizontalAxisName) * moveSpeed;
		float vertical = Input.GetAxis(verticalAxisName) * moveSpeed;
        moveVector = new Vector2(horizontal, vertical);
		if(moveVector.magnitude > 1f){
			moveVector.Normalize ();
		}




	}

    void FixedUpdate() {
		myRigidbody.velocity = moveVector * moveSpeed * Time.deltaTime * 10f;

		if(moveVector.magnitude != 0f){
			transform.up = moveVector.normalized;
			lastDirection = moveVector.normalized;
		}else{
			transform.up = lastDirection;
		}

    }

	// translate a Direction enum to a normalized Vector3
	Vector3 DirectionToVector(Direction dir){
		if(dir == Direction.NORTH){
			return new Vector3 (0f, 1f, 0f);
		}else if(dir == Direction.SOUTH){
			return new Vector3 (0f, -1f, 0f);
		}else if(dir == Direction.EAST){
			return new Vector3 (1f, 0f, 0f);
		}else if (dir == Direction.WEST){
			return new Vector3 (-1f, 0f, 0f);
		}else{
			return new Vector3 (0f, 0f, 0f);
		}
	}
}
