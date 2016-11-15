using UnityEngine;
using System.Collections;

public class elmargame : MonoBehaviour {


	public UnityEngine.UI.InputField field;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (field.text);
	}
}
