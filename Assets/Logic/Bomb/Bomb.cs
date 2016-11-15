using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	public float radius;
	public float power;
	public LayerMask targetMask;


	private bool isExploded = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void trigger(){
		if (!isExploded) {
			isExploded = true;
			explode ();
		}

	}

	public void explode(){

		RaycastHit2D[] hits = Physics2D.CircleCastAll (transform.position, radius, Vector2.zero, 0, targetMask);

		foreach (RaycastHit2D target in hits) {


			Rigidbody2D newRigidbody =
				(target.collider.GetComponent<Rigidbody2D>() == null)?
				target.collider.gameObject.AddComponent<Rigidbody2D> ():
				target.collider.GetComponent<Rigidbody2D>();
			
			newRigidbody.freezeRotation = true;
			newRigidbody.AddForce ((target.transform.position - transform.position).normalized * power);
		}

		Destroy (this.gameObject);

	}
}
