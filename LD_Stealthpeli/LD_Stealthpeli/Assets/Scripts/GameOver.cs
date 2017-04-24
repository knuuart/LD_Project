using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
	GameManagerScript gm;

	// Use this for initialization
	void Start () {
		gm = GetComponent<GameManagerScript> ();

	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameManagerScript.ShameMeter = 0;
			SceneManager.LoadScene ("alkuruutu");
			
		}
	}
}
