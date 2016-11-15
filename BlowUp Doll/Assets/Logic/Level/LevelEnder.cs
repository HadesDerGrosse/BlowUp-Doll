using UnityEngine;
using System.Collections;

public class LevelEnder : MonoBehaviour {


	private GameObject[] players;
	// Use this for initialization

	void Start () {
		players = GameObject.FindGameObjectsWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		foreach (GameObject player in players) {
			if (Vector2.Distance (player.transform.position, transform.position) < 1) {
				endLevel (true);
			}
		}
	}

	public void endLevel(bool won){

		if (won)
			Debug.Log ("WON");

	}
}
