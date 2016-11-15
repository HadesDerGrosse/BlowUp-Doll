using UnityEngine;
using System.Collections;

public class SinMovement : MonoBehaviour {


    public Vector3 movement;
    public float frequence;

    private Vector3 startPosition;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position = startPosition + Mathf.Sin(Time.time * frequence)*movement;
	}
}
