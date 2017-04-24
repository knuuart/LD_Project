using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSightSensor : MonoBehaviour {

    public LayerMask wallsOnly;
    public float maximumSightDistance;
    float maximumSightAngle = 1;
    GameObject go;
    ConversationScript cs;
    GameManagerScript gm;
    EnemyMovement em;
    bool seenThePlayer = false;

    
    void Start () {

        go = GameObject.FindGameObjectWithTag("Player");
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerScript>();


        cs = GetComponentInParent<ConversationScript>();
        


	}
	
	
	void Update () {

        

        if (gm.currentState == GameManagerScript.GameState.Running)
        {

            bool visible;

            var p = go.transform.position;

            var toPlayer = p - transform.position;

            var distance = toPlayer.magnitude;

            var angle = Vector3.Angle(transform.up, toPlayer);

            visible = angle < maximumSightAngle && distance < maximumSightDistance;

            if (!seenThePlayer && visible && !Physics.Raycast(transform.position, p - transform.position, (p - transform.position).magnitude, wallsOnly))
            {
                Debug.DrawRay(transform.position, p - transform.position);
                Debug.Log("Oi mate!!");
                cs.enabled = true;
                gm.currentState = GameManagerScript.GameState.Conversation;
            }



            //  seenThePlayer = true;
        }
        else return;
//        else print("EI NÄY");

	}
}
