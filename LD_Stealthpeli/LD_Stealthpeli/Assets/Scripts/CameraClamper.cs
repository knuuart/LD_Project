using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamper : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, 0f, 0f),
											Mathf.Clamp(transform.position.y, -20f, 20),
											Mathf.Clamp(transform.position.z, -10f, -10f));
	}
}
