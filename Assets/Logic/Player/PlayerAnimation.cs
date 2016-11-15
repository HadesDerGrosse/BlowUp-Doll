using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

    public PlayerMovement move;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (move.movementType == PlayerMovement.MovementTyps.RUN_RIGHT)
            transform.localScale = new Vector3(-1, 1, 1);

        else if(move.movementType == PlayerMovement.MovementTyps.RUN_LEFT)
            transform.localScale = Vector3.one;

        //Debug.Log(transform.localScale.x);
	}
}
