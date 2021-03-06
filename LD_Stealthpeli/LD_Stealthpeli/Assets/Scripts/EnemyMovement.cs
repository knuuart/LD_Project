﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed;
    public Transform[] waypoints;
    public float tolerance = 1f;
	public int targetIndex = 0;
    GameManagerScript gm;
	Vector2 dir;
	public bool mummo, bro, teacher, rasta;
    public bool seenThePlayer = false;

	Animator anim;


	// Use this for initialization
	void Start () {
		anim = GetComponentInChildren<Animator> ();
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerScript>();
    }
	
	// Update is called once per frame
	void Update () {

		if (gm.currentState != GameManagerScript.GameState.Running) {
			anim.enabled = false;
			return;

		} else {
			anim.enabled = true;
		}
        dir = waypoints [targetIndex].position - transform.position;
        MoveToPoint();
//        Turner();
		PatrolAnimation ();
		
    }

    void MoveToPoint()
    {
		Turner ();
        transform.position = Vector3.MoveTowards(transform.position, waypoints[targetIndex].position, Time.deltaTime * speed);

        Vector3 direction;
        direction = waypoints[targetIndex].position - transform.position;

       if(direction.magnitude < tolerance)
        {
            targetIndex += 1;
            if(targetIndex == waypoints.Length)
            {
                targetIndex = 0;
//                transform.up = waypoints[targetIndex].position - transform.position;
            }
        }
    }

	public void Turner()
    {
		transform.up = waypoints [targetIndex].position - transform.position;
    }
	void PatrolAnimation(){
		if (mummo) {
			if (dir.y > 0.2f) {
				anim.Play ("Grandma_up");
			} 
			if (dir.x > 0.2f) {
				anim.Play ("Grandma_right");
			}
			if (dir.y < -0.2f) {
				anim.Play ("Grandma_down");
			}
			if (dir.x < -0.2f) {
				anim.Play ("Grandma_left");
			}
		}
		if (bro) {
			if (dir.y > 0.2f) {
				anim.Play ("bro_up");
			} 
			if (dir.x > 0.2f) {
				anim.Play ("bro_right");
			}
			if (dir.y < -0.2f) {
				anim.Play ("bro_down");
			}
			if (dir.x < -0.2f) {
				anim.Play ("bro_left");
			}
		}
		if (teacher) {
			if (dir.y > 0.2f) {
				anim.Play ("teacher_up");
			} 
			if (dir.x > 0.2f) {
				anim.Play ("teacher_right");
			}
			if (dir.y < -0.2f) {
				anim.Play ("teacher_down");
			}
			if (dir.x < -0.2f) {
				anim.Play ("teacher_left");
			}
		}
		if (rasta) {
			if (dir.y > 0.2f) {
				anim.Play ("joku_up");
			} 
			if (dir.x > 0.2f) {
				anim.Play ("joku_right");
			}
			if (dir.y < -0.2f) {
				anim.Play ("joku_down");
			}
			if (dir.x < -0.2f) {
				anim.Play ("joku_left");
			}
		}
	}
}
