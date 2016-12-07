using UnityEngine;
using System.Collections;

public class LevelEnder : MonoBehaviour {


	private GameObject[] players;
	private bool gameEnded = false;
	// Use this for initialization

	void Start () {
		players = GameObject.FindGameObjectsWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if (gameEnded)
			return;
		
		foreach (GameObject player in players) {
			if (Vector2.Distance (player.transform.position, transform.position) < 1) {
				gameEnded = true;
				endLevel (true);
			}
		}
	}

	public void endLevel(bool won){

		if (won) {			
			GameObject.FindGameObjectWithTag ("endUI").transform.GetChild(0).gameObject.SetActive (true);
			gameObject.GetComponent<Bomb> ().trigger ();
		}

	}
}
