using UnityEngine;
using System.Collections;

public class PlayerKiller : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        GameManager.endGame += GameEnd;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    private void GameEnd(bool won)
    {

    }
}
