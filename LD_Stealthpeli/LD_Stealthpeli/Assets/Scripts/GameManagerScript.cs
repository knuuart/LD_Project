using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {

    public enum GameState { GameOver, Running, Paused, Conversation, Bossfight};

   public static int ShameMeter = 0;
    public const int shameThreshold =50 ;
    public Sprite sprite;
    Image sr1;
    Text sr2;
    Image ci1;
    public bool isBossFight;
    
    EnemyMovement em;
   

    public GameState currentState;

    // Use this for initialization


    

	void Start () {
        currentState = GameState.Running;
        sr1 = GameObject.Find("ConversationCanvas").GetComponentInChildren<Image>();
        sr2 = GameObject.Find("Image").GetComponentInChildren<Text>();
        ci1 = GameObject.Find("CloseImage1").GetComponent<Image>();


    }
	
	// Update is called once per frame
	void Update () {
        DeathByShame();

        if(currentState == GameState.Conversation)
        {
            


            sr1.enabled = true;
            sr2.enabled = true;
            ci1.GetComponent<Image>().sprite = sprite;
            ci1.enabled = true;

            
        } 
        else
        {
            sr1.enabled = false;
            sr2.enabled = false;
            ci1.enabled = false;
        }




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
        SceneManager.LoadScene("loppuscene");
    }

    void StartConversation()
    {
//		Application.LoadLevel ()
    }



    }

