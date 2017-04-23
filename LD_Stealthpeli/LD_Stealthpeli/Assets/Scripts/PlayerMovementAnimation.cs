﻿using UnityEngine;
using System.Collections;

public class PlayerMovementAnimation : MonoBehaviour {

	Animator anim;

	Vector3 pos;
	public float speed;
	public LayerMask wallsOnly;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();
		Vector3 pos = transform.position;


	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;

		if (Input.GetKey(KeyCode.A) && transform.position == pos && !Physics.Raycast(transform.position, Vector3.left, 1.4f, wallsOnly))
		{
			pos += Vector3.left;
		} 

		if (Input.GetKey(KeyCode.D) && transform.position == pos && !Physics.Raycast(transform.position, Vector3.right, 1.4f, wallsOnly))
		{
			pos += Vector3.right;
		}

		if (Input.GetKey(KeyCode.S) && transform.position == pos && !Physics.Raycast(transform.position, Vector3.down, 1.4f, wallsOnly))
		{
			pos += Vector3.down;
		}

		if (Input.GetKey (KeyCode.W) && transform.position == pos && !Physics.Raycast (transform.position, Vector3.up, 1.4f, wallsOnly)) 
		{
			pos += Vector3.up;
		}

		float move = Input.GetAxis ("Vertical");
		anim.SetFloat ("Speed", move);
		float move2 = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed2", move2);



		transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);



	}

}