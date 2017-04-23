﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Vector3 pos;
    public float speed;
    public LayerMask wallsOnly;

    private void Start()
    {
        Vector3 pos = transform.position;
    }
	
	void Update () {
    /*
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        MovePlayer(new Vector3(hAxis, 0, vAxis) * speed * Time.deltaTime);
        */
        /*
            float hAxis = Input.GetAxis("Horizontal");
            float vAxis = Input.GetAxis("Vertical");

            MovePlayer(new Vector3(hAxis, 0, vAxis) * speed * Time.deltaTime);
            */
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

        if (Input.GetKey(KeyCode.W) && transform.position == pos && !Physics.Raycast(transform.position, Vector3.up, 1.4f, wallsOnly))
        {
            pos += Vector3.up;
        }


        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);



    }
    /*
    void MovePlayer (Vector3 dir)
    {
        transform.position += dir;
    }
    */


    void OnTriggerEnter(Collider boi) 
    {
        if (boi.gameObject.tag == "Goal")
        {
            Debug.Log("Pääsit maaliin?!");
        }
    }
}
