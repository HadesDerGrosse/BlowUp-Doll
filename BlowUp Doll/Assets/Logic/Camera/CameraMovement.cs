using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public GameObject player;
	public float dumping;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Vector3 position = Vector3.MoveTowards (transform.position, player.transform.position, Vector2.Distance(transform.position, player.transform.position) * Time.deltaTime);
		position.z = -10;
		transform.position = position;

	}
}
