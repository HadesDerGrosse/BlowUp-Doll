using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


	PlayerProperties playerProperties;
    PlayerInputHandler playerInput;
	PlayerPhysic physics;
	public LayerMask collidesWith;

	public enum MovementTyps {
		STAND,
		LEAN_LEFT,
		LEAN_RIGHT,
		RUN_LEFT,
		RUN_RIGHT,
		JUMP,
		JUMP_RIGHT,
		JUMP_LEFT,
		FALL,
		FALL_LEFT,
		FALL_RIGHT,
		SLIDE_RIGHT,
		SLIDE_LEFT
	};

	public MovementTyps movementType;


    void Awake() { 
		playerInput 		= GetComponent<PlayerInputHandler> ();
		playerProperties 	= GetComponent<PlayerProperties> ();
		physics 			= GetComponent<PlayerPhysic> ();
	}

	// Update is called once per frame
	void Update () {
		detectMovement ();
		Jump ();
		Run ();
        Dive();

		handleMovement ();
	}






	private void Jump(){

        if (playerInput.Jump == 0)
            return;

        if(physics.hasCollisionBottom)
        {
            physics.Velocity =
                new Vector2(
                    physics.Velocity.x,
                    Mathf.Sqrt(2 * physics.playerGravity * playerProperties.jumpHeight) * playerInput.Jump
                );
        }

	}

	private void Run(){

		Vector2 movement = new Vector2 (playerInput.Right * playerProperties.runSpeed, physics.Velocity.y);


		if (
			(physics.hasCollisionLeft && playerInput.Right < 0) ||
			(physics.hasCollisionRight && playerInput.Right > 0)) {

			return;

		}

		physics.Velocity = movement;
	}


    private void Dive()
    {
        if (!physics.hasCollisionBottom && playerInput.Dive < 0)
        {
            physics.AddForce(new Vector2(0,playerProperties.diveStrength));
        }
    }


	private void detectMovement(){

		if(physics.hasCollisionBottom && physics.Velocity.x == 0)
			movementType = MovementTyps.STAND;

		if(physics.hasCollisionBottom && !physics.hasCollisionLeft && physics.Velocity.x < 0)
			movementType = MovementTyps.RUN_LEFT;

		if(physics.hasCollisionBottom && !physics.hasCollisionRight && physics.Velocity.x > 0)
			movementType = MovementTyps.RUN_RIGHT;

		if(physics.hasCollisionBottom && physics.hasCollisionLeft && playerInput.Right < 0)
			movementType = MovementTyps.LEAN_LEFT;

		if(physics.hasCollisionBottom && physics.hasCollisionRight && playerInput.Right > 0)
			movementType = MovementTyps.LEAN_RIGHT;		




		if(!physics.hasCollisionBottom && physics.Velocity.x == 0 && physics.Velocity.y < 0)
			movementType = MovementTyps.FALL;

		if(!physics.hasCollisionBottom && physics.Velocity.x < 0 && physics.Velocity.y < 0 && !physics.hasCollisionLeft && !physics.hasCollisionRight)
			movementType = MovementTyps.FALL_LEFT;

		if(!physics.hasCollisionBottom && physics.Velocity.x > 0 && physics.Velocity.y < 0 && !physics.hasCollisionLeft && !physics.hasCollisionRight)
			movementType = MovementTyps.FALL_RIGHT;

		if(!physics.hasCollisionBottom && physics.Velocity.y < 0 && physics.hasCollisionLeft && playerInput.Right < 0)
			movementType = MovementTyps.SLIDE_LEFT;

		if(!physics.hasCollisionBottom && physics.Velocity.y < 0 && physics.hasCollisionRight && playerInput.Right > 0)
			movementType = MovementTyps.SLIDE_RIGHT;
		



		if(!physics.hasCollisionBottom && physics.Velocity.x == 0 && physics.Velocity.y > 0)
			movementType = MovementTyps.JUMP;

		if(!physics.hasCollisionBottom && physics.Velocity.x < 0 && physics.Velocity.y > 0)
			movementType = MovementTyps.JUMP_LEFT;

		if(!physics.hasCollisionBottom && physics.Velocity.x > 0 && physics.Velocity.y > 0)
			movementType = MovementTyps.JUMP_RIGHT;


	}

	public void handleMovement(){

		if (movementType == MovementTyps.SLIDE_LEFT || movementType == MovementTyps.SLIDE_RIGHT) {

			physics.Velocity.Set(0,Mathf.Min(physics.Velocity.y,5));

		}
	}

}
