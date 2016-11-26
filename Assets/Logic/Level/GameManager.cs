using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Canvas startUI;

    public delegate void StartEvent();
    public delegate void EndEvent(bool won);

    public static StartEvent startGame;
    public static EndEvent endGame;

	// Use this for initialization
	void Awake () {
        Time.timeScale = 0f;
        startGame += StartGame;
    }

    private void StartGame()
    {
        Time.timeScale = 0.5f;
        startUI.gameObject.SetActive(false);
    }

    private void EndGame()
    {
        Time.timeScale = 0f;
        startUI.gameObject.SetActive(true);
    }


    public void TriggerStartGame()
    {
        startGame();
    }

    public void TriggerEndGame(bool won)
    {
        endGame(won);
    }
}
