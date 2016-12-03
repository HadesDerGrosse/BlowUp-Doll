using UnityEngine;
using System.Collections;

public class FakeParrallax : MonoBehaviour {

    public GameObject cam;
    [Tooltip("1 is like parented to cam, 0 is static to world")]
    public Vector2 parrallaxSpeed;

    private Vector3 startPos;
    private Vector3 camStartPos;

	// Use this for initialization
	void Awake () {
        startPos = transform.position;
        camStartPos = cam.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = startPos + Vector3.Scale((cam.transform.position - camStartPos) , (Vector3)parrallaxSpeed);
	}
}
