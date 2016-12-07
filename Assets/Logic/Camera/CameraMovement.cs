using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private GameObject[] players;
	public float damping;

	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag ("Player");
	}
	
	// Update is called once per frame
	void LateUpdate () {


			
		Vector3 averagePlayerPos = getAveragePlayerPosition ();
		Vector3 newCameraPosition;

		newCameraPosition = Vector3.MoveTowards (transform.position, averagePlayerPos, Vector2.Distance(transform.position, averagePlayerPos) * Time.deltaTime * damping);
		newCameraPosition.z = -10;
		transform.position = newCameraPosition;

	}

	public Vector3 getAveragePlayerPosition(){

		if (players [0] == null)
			return this.transform.position;

		Vector3 position = new Vector3 ();

		foreach (GameObject player in players) {
			position += player.transform.position;
		}

		return position / players.Length;
	}
}
