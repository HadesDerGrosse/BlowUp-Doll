using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Canvas startUI;

    private static bool foerst = true;

    public delegate void StartEvent();
    public delegate void EndEvent(bool won);

    public static StartEvent startGame;
    public static EndEvent endGame;

	// Use this for initialization
	void Awake () {
        Time.timeScale = 0f;
        startGame += StartGame;
    }

    void Start()
    {
        if (!foerst)
            TriggerStartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 0.5f;
        startUI.gameObject.SetActive(false);
        foerst = false;
    }

    private void EndGame()
    {
        Time.timeScale = 0f;
        startUI.gameObject.SetActive(true);
    }


    public static void TriggerStartGame()
    {
        startGame();
    }

    public static void TriggerEndGame(bool won)
    {
        endGame(won);
    }

	public void QuitGame(){
		Application.Quit();
	}

    void OnDestroy()
    {
        startGame = null;
        endGame = null;
    }
}
