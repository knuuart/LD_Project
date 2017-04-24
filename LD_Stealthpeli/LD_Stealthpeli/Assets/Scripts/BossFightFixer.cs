using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightFixer : MonoBehaviour {

    GameManagerScript gm;

	// Use this for initialization
	void Start () {
        gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

		
	}
	
	// Update is called once per frame
	void Update () {

        gm.currentState = GameManagerScript.GameState.Conversation;

		
	}
}
