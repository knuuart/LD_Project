using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Alkuruutu : MonoBehaviour {

	float aika;
	public GameObject teksti, teksti2, alkukuva;
	int presses = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		aika += Time.deltaTime;
		if (aika > 3f && presses == 0) {
			teksti.SetActive(true);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			teksti.SetActive (false);
			alkukuva.SetActive (false);
			presses++;
			teksti2.SetActive (true);
			if(presses == 2){
				SceneManager.LoadScene("testiskene_2");
			}
		}
	}
}
