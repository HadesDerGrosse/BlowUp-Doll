using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	public float radius;
	public float power;
	public LayerMask targetMask;
    public GameObject explosion;
    public float delay = 0.5f;


	private bool isExploded = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void trigger(){
		if (!isExploded) {
            StartCoroutine(Wait(delay * Time.timeScale));

			this.GetComponentInChildren<Animator>().SetTrigger("trigger");
            isExploded = true;
		}
	}

    private IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        explode();
    }

	public void explode(){

		RaycastHit2D[] hits = Physics2D.CircleCastAll (transform.position, radius, Vector2.zero, 0, targetMask);

		foreach (RaycastHit2D target in hits) {


			Rigidbody2D newRigidbody =
				(target.collider.GetComponent<Rigidbody2D>() == null)?
				target.collider.gameObject.AddComponent<Rigidbody2D> ():
				target.collider.GetComponent<Rigidbody2D>();
			
			newRigidbody.freezeRotation = true;
			newRigidbody.AddForce (((target.transform.position - transform.position).normalized + Vector3.up) * power * 4);

            if (target.collider.GetComponent<Bomb>() != null)
                target.collider.GetComponent<Bomb>().trigger();
		}


        Destroy(Instantiate(explosion, this.transform.position, this.transform.rotation),5);

		Destroy (this.gameObject);



	}
}
