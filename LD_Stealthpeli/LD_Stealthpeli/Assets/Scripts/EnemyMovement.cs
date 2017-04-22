using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed;
    public Transform[] waypoints;
    public float tolerance = 1f;
    int targetIndex = 0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveToPoint();
		
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
            }
        }
    }
}
