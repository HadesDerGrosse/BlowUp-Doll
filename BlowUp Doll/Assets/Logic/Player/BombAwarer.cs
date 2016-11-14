using UnityEngine;
using System.Collections;

public class BombAwarer : MonoBehaviour
{

	public float radius;
	public LayerMask mask;

	// Use this for initialization
	void Start ()
	{
	
	}

	// Update is called once per frame
	void Update ()
	{
		foreach (RaycastHit2D bomb in Physics2D.CircleCastAll (transform.position, radius, Vector2.zero, 0, mask)) {
			Debug.Log ("EXPLODE");
			bomb.collider.gameObject.GetComponent<Bomb> ().trigger ();
		}
	}
}

