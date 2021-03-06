﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerMovementAnimation : MonoBehaviour {

	Animator anim;

	Vector3 pos;
	public float speed;
	public LayerMask wallsOnly;

    public enum PowerUpType { None, NewsPaper };

    public float powerUpDuration;
    float powerUpTimeLeft;
    PowerUpType activePowerUp;

    GameManagerScript gm;


    // Use this for initialization
    void Start () {

		anim = GetComponent<Animator>();
		Vector3 pos = transform.position;
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerScript>();
        

    }
	
	// Update is called once per frame
	void Update () {

        

        if (gm.currentState != GameManagerScript.GameState.Running)
        {
            anim.enabled = false;
            return;

        }

        else

        {
            anim.enabled = true;

            RaycastHit hit;

            if (Input.GetKey(KeyCode.LeftArrow) && transform.position == pos && !Physics.Raycast(transform.position, Vector3.left, 1.4f, wallsOnly))
            {
                pos += Vector3.left;
            }

            if (Input.GetKey(KeyCode.RightArrow) && transform.position == pos && !Physics.Raycast(transform.position, Vector3.right, 1.4f, wallsOnly))
            {
                pos += Vector3.right;
            }

            if (Input.GetKey(KeyCode.DownArrow) && transform.position == pos && !Physics.Raycast(transform.position, Vector3.down, 1.4f, wallsOnly))
            {
                pos += Vector3.down;
            }

            if (Input.GetKey(KeyCode.UpArrow) && transform.position == pos && !Physics.Raycast(transform.position, Vector3.up, 1.4f, wallsOnly))
            {
                pos += Vector3.up;
            }

            float move = Input.GetAxis("Vertical");
            anim.SetFloat("Speed", move);
            float move2 = Input.GetAxis("Horizontal");
            anim.SetFloat("Speed2", move2);



            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);

        }


	}

    public void NewPowerUp(PowerUpType p)
    {
        powerUpTimeLeft = powerUpDuration;

        activePowerUp = p;

        StartPowerUp(p);
    }

    void StartPowerUp(PowerUpType p)
    {
        if (p == PowerUpType.NewsPaper)
        {
            gameObject.layer = 0;
        }
    }

    void EndPowerUp(PowerUpType p)
    {
        if (p == PowerUpType.NewsPaper)
        {
            gameObject.layer = 8;
        }
    }

    void OnTriggerEnter(Collider boi)
    {
        if (boi.gameObject.tag == "Goal")
        {
            print("Pääsit maaliin?!");

            SceneManager.LoadScene("bossfight_milkstore");
            gm.currentState = GameManagerScript.GameState.Conversation;




        }


    }

    }
