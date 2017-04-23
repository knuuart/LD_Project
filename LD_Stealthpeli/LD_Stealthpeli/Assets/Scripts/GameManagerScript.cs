using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    public enum GameState { GameOver, Running, Paused};

    public int ShameMeter = 0;
    public int shameThreshold;
   

    GameState currentState;

	// Use this for initialization
	void Start () {
        currentState = GameState.Running;
		
	}
	
	// Update is called once per frame
	void Update () {
        DeathByShame();
		
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
	//	Application.LoadLevel ()
    }
}
