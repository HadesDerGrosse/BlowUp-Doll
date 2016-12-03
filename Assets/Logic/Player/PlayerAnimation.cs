using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

    public PlayerMovement move;
    public PlayerPhysic phys;
    public Animator anim;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //SPRITE FLIPPING
        if (move.movementType == PlayerMovement.MovementTyps.RUN_RIGHT
            ||move.movementType == PlayerMovement.MovementTyps.JUMP_RIGHT
            || move.movementType == PlayerMovement.MovementTyps.FALL_RIGHT
            )
            transform.localScale = new Vector3(-1, 1, 1);

        else if(move.movementType == PlayerMovement.MovementTyps.RUN_LEFT
            || move.movementType == PlayerMovement.MovementTyps.JUMP_LEFT
            || move.movementType == PlayerMovement.MovementTyps.FALL_LEFT
            )
            transform.localScale = Vector3.one;

        //SETTING BOOLS TO ANIMATOR
        anim.SetBool("jump", (move.movementType == PlayerMovement.MovementTyps.JUMP
            || move.movementType == PlayerMovement.MovementTyps.JUMP_RIGHT
            || move.movementType == PlayerMovement.MovementTyps.JUMP_LEFT)
            );



        anim.SetBool("standing", (move.movementType == PlayerMovement.MovementTyps.RUN_LEFT
            || move.movementType == PlayerMovement.MovementTyps.RUN_RIGHT
            || move.movementType == PlayerMovement.MovementTyps.STAND)
            );

        
        anim.SetBool("fall", (move.movementType == PlayerMovement.MovementTyps.FALL
            || move.movementType == PlayerMovement.MovementTyps.FALL_LEFT
            || move.movementType == PlayerMovement.MovementTyps.FALL_RIGHT)
            );

        anim.SetFloat("xVel", Mathf.Abs(phys.Velocity.x));
	}
}
