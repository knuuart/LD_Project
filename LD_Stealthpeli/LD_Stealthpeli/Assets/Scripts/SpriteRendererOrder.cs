using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRendererOrder : MonoBehaviour {

    SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        sr.sortingOrder = (int) -transform.position.y *3;
		
	}
}
