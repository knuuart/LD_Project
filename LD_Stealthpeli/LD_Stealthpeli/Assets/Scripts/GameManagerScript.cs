﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    public enum GameState { GameOver, Running, Paused, Conversation};

    public int ShameMeter = 0;
    public int shameThreshold;
    Image sr1;
    Text sr2;
   

    public GameState currentState;

	// Use this for initialization
	void Start () {
        currentState = GameState.Running;
        sr1 = GameObject.Find("ConversationCanvas").GetComponentInChildren<Image>();
        sr2 = GameObject.Find("Image").GetComponentInChildren<Text>();

    }
	
	// Update is called once per frame
	void Update () {
        DeathByShame();

        if(currentState == GameState.Conversation)
        {
            sr1.enabled = true;
            sr2.enabled = true;
            
        } else
        {
            sr1.enabled = false;
            sr2.enabled = false;
        }

        ReturnGameState();


    }

    public void ShameReceiver(int shameAmount)
    {

        ShameMeter += shameAmount;

    }

    public void ShameReducer(int shameAmount)
    {
        ShameMeter -= shameAmount;
    }


    public int ShowShame()
    {
        return ShameMeter;
    }

    void DeathByShame()
    {
        if(ShameMeter > shameThreshold)
        {
            currentState = GameState.GameOver;
            GameOver();
        }
    }


    void GameOver()
    {
        Debug.LogError("You couldn't deal with the shame, and had to return home.");
    }

    void StartConversation()
    {
//		Application.LoadLevel ()
    }


    void ReturnGameState()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            currentState = GameState.Running;
        }
    }
}
