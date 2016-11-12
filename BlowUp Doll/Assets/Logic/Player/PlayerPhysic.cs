using UnityEngine;
using System.Collections;

public class PlayerPhysic : MonoBehaviour {

	public LayerMask collidesWith;
	public float innerThrashhold = 0.1f;
	public float outerThrashhold = 0.1f;
	private float rayLenght;

	public RaycastHit2D characterHit;
	public bool hasCollisionBottom;
	public bool hasCollisionRight;
	public bool hasCollisionLeft;
	public bool hasCollisionTop;

	public GameObject leftCollisionObject;
	public GameObject rightCollisionObject;
	public GameObject topCollisionObject;
	public GameObject bottomCollisionObject;




	Rigidbody2D rigidbody;
	private Vector2 currentForce;
	private Vector2 currentVelocity;

	public Vector2 Velocity {
		get{ return currentVelocity; }
		set{ currentVelocity = value; }
	}


	void Awake(){

		rigidbody = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
		
	}


	void FixedUpdate(){
		rayLenght = innerThrashhold + outerThrashhold;

        checkGroundCollision();
		checkLeftCollision ();
		checkCollisionRight ();
		checkCollisionTop ();


        if (hasCollisionBottom)
            this.transform.parent = bottomCollisionObject.transform;

        else
            this.transform.parent = null;




        currentVelocity += Vector2.down * 9.81f * Time.fixedDeltaTime;

		handleCollision ();

		transform.position += new Vector3(currentVelocity.x, currentVelocity.y,0)*Time.fixedDeltaTime;
		currentForce.Set (0, 0);




	}

	public void AddForce(Vector2 f){
		currentForce += f;
	}

	public void setVelocity(Vector2 v){
		currentVelocity = v;
	}


	private void handleCollision(){

		if (hasCollisionBottom && currentVelocity.y < 0)
			currentVelocity.Set (currentVelocity.x, 0);

		if (hasCollisionTop && currentVelocity.y > 0)
			currentVelocity.Set (currentVelocity.x, 0);

		if (hasCollisionRight && currentVelocity.x > 0)
			currentVelocity.Set (0, currentVelocity.y);

		if (hasCollisionLeft && currentVelocity.x < 0)
			currentVelocity.Set (0, currentVelocity.y);


	}



	private void checkGroundCollision(){

		Debug.DrawRay(transform.position + new Vector3(-0.45f,innerThrashhold,0), Vector2.down *rayLenght);
		Debug.DrawRay(transform.position + new Vector3(-0.0f,innerThrashhold,0), Vector2.down *rayLenght);
		Debug.DrawRay(transform.position + new Vector3(+0.45f,innerThrashhold,0), Vector2.down *rayLenght);

        if(currentVelocity.y > 0)
        {
            hasCollisionBottom = false;
            return;
        }

		characterHit = Physics2D.Raycast (transform.position+new Vector3(-0.0f,innerThrashhold,0), Vector2.down, rayLenght, collidesWith);
		if (characterHit.collider == null) {
			characterHit = Physics2D.Raycast (transform.position+new Vector3(-0.45f,innerThrashhold,0), Vector2.down, rayLenght,collidesWith);
			if (characterHit.collider == null) {
				characterHit = Physics2D.Raycast (transform.position+new Vector3(+0.45f,innerThrashhold,0), Vector2.down, rayLenght,collidesWith);
				if (characterHit.collider == null) {
					hasCollisionBottom = false;
					bottomCollisionObject = null;
					return;
				}
			}
		}

		hasCollisionBottom = true;
		bottomCollisionObject = characterHit.collider.gameObject;
		transform.position= new Vector3(transform.position.x,characterHit.point.y,0);

	}

	private void checkLeftCollision(){

		Debug.DrawRay(transform.position + new Vector3(-0.4f,0.05f,0), Vector2.left *rayLenght);
		Debug.DrawRay(transform.position + new Vector3(-0.4f,1.00f,0), Vector2.left *rayLenght);
		Debug.DrawRay(transform.position + new Vector3(-0.4f,1.95f,0), Vector2.left *rayLenght);

		characterHit = Physics2D.Raycast (transform.position + new Vector3(-0.4f,0.05f,0), Vector2.left, rayLenght, collidesWith);
		if (characterHit.collider == null) {
			characterHit = Physics2D.Raycast (transform.position+new Vector3(-0.4f,1.00f,0), Vector2.left, rayLenght,collidesWith);
			if (characterHit.collider == null) {
				characterHit = Physics2D.Raycast (transform.position+new Vector3(-0.4f,1.95f,0), Vector2.left, rayLenght,collidesWith);
				if (characterHit.collider == null) {
					hasCollisionLeft = false;
					leftCollisionObject = null;
					return;
				}
			}
		}

		hasCollisionLeft = true;
		leftCollisionObject = characterHit.collider.gameObject;
        transform.position = new Vector3(characterHit.point.x+0.5f, transform.position.y, 0);
    }

	private void checkCollisionRight(){

		Debug.DrawRay(transform.position + new Vector3(0.4f,0.05f,0), Vector2.right *rayLenght);
		Debug.DrawRay(transform.position + new Vector3(0.4f,1f,0), Vector2.right *rayLenght);
		Debug.DrawRay(transform.position + new Vector3(0.4f,1.95f,0), Vector2.right *rayLenght);

		characterHit = Physics2D.Raycast (transform.position + new Vector3(0.4f,0.05f,0), Vector2.right, rayLenght, collidesWith);
		if (characterHit.collider == null) {
			characterHit = Physics2D.Raycast (transform.position+new Vector3(0.4f,1f,0), Vector2.right, rayLenght,collidesWith);
			if (characterHit.collider == null) {
				characterHit = Physics2D.Raycast (transform.position+new Vector3(0.4f,1.95f,0), Vector2.right, rayLenght,collidesWith);
				if (characterHit.collider == null) {
					hasCollisionRight = false;
					rightCollisionObject = null;
					return;
				}
			}
		}

		hasCollisionRight = true;
		rightCollisionObject = characterHit.collider.gameObject;

	}

	private void checkCollisionTop(){
		Debug.DrawRay(transform.position + new Vector3(-0.4f,1.9f,0), Vector2.up *rayLenght);
		Debug.DrawRay(transform.position + new Vector3(0.0f,1.9f,0), Vector2.up *rayLenght);
		Debug.DrawRay(transform.position + new Vector3(0.4f,1.9f,0), Vector2.up *rayLenght);

		characterHit = Physics2D.Raycast (transform.position + new Vector3(-0.0f,1.9f,0), Vector2.up, rayLenght, collidesWith);
		if (characterHit.collider == null) {
			characterHit = Physics2D.Raycast (transform.position+new Vector3(0.4f,1.9f,0), Vector2.up, rayLenght,collidesWith);
			if (characterHit.collider == null) {
				characterHit = Physics2D.Raycast (transform.position+new Vector3(-0.4f,1.9f,0), Vector2.up, rayLenght,collidesWith);
				if (characterHit.collider == null) {
					hasCollisionTop = false;
					topCollisionObject = null;
					return;
				}
			}
		}

		hasCollisionTop = true;
		topCollisionObject = characterHit.collider.gameObject;
	}
}
