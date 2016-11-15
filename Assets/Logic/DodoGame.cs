using UnityEngine;
using System.Collections;

public class DodoGame : MonoBehaviour {

	public GameObject camera;


	// Use this for initialization
	void Start () {
	
	}


	// Wird nur aufgerufen wenn das Spielbrett angeklickt wird
	void OnMouseDown(){

		//Wird nur aufgerufen wenn die Linke Maustaste gedrückt wird
		if (Input.GetKeyDown (KeyCode.Mouse0)) {

			//Speichert die Umgerechneten Weltcoordinaten in die x && y werte
			int x = (int)Camera.main.ScreenToWorldPoint (Input.mousePosition).x;
			int y = (int)Camera.main.ScreenToWorldPoint (Input.mousePosition).y;

			//Dumme Ausgabe
			Debug.Log(Input.mousePosition+ " --- "+x+" || "+y);
		}
	}



}
