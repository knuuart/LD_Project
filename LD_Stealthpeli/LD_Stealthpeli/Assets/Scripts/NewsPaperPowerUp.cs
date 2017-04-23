using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsPaperPowerUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    private void OnTriggerEnter(Collider boi)
    {
        if(boi.gameObject.tag == "Player")
        {
            print("Gotcha!");
            boi.GetComponent<PlayerMovement>().NewPowerUp(PlayerMovement.PowerUpType.NewsPaper);
            
            Destroy(gameObject);
        }
    }
}
