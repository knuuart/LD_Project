using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSightSensor : MonoBehaviour {

    public LayerMask wallsOnly;
    public float maximumSightDistance;
    float maximumSightAngle = 1;
    GameObject go;

    
    void Start () {

        go = GameObject.FindGameObjectWithTag("Player");

	}
	
	
	void Update () {

        bool visible;

        var p = go.transform.position;

        var toPlayer = p - transform.position;

        var distance = toPlayer.magnitude;

        var angle = Vector3.Angle(transform.up, toPlayer);

        visible = angle < maximumSightAngle && distance < maximumSightDistance;

        if (visible && !Physics.Raycast(transform.position, p - transform.position, (p - transform.position).magnitude, wallsOnly))
        {
            Debug.DrawRay(transform.position, p - transform.position);
            Debug.Log("Oi mate!!");
        }
//        else print("EI NÄY");

	}
}
