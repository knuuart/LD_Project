using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed;
    public Transform[] waypoints;
    public float tolerance = 1f;
    int targetIndex = 0;
    GameManagerScript gm;

	Animator anim;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
        MoveToPoint();
//        Turner();
		if (targetIndex == 1){
			anim.SetBool ("GoingUp", true);
		}
		if (targetIndex == 2) {
			anim.SetBool ("GoingRight", true);
		}
		if (targetIndex == 3) {
			anim.SetBool ("GoingDown", true);
		}
		if (targetIndex == 0) {
			anim.SetBool ("GoingLeft", true);
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

    void Turner()
    {
        transform.up = waypoints[targetIndex].position - transform.position;
    }
}
