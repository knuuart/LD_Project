using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed;
    public Transform[] waypoints;
    public float tolerance = 1f;
	public int targetIndex = 0;
    GameManagerScript gm;
	Vector2 dir;

	Animator anim;


	// Use this for initialization
	void Start () {
		anim = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		dir = waypoints [targetIndex].position - transform.position;
        MoveToPoint();
        Turner();
//		anim.Play ("Grandma_right");
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


    void MoveToPoint()
    {
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
}
