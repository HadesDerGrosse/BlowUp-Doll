using UnityEngine;
using System.Collections;

public class PlayerKiller : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        GameManager.endGame += GameEnd;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -10)
            GameManager.TriggerEndGame(false);
	}


    private void GameEnd(bool won)
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
