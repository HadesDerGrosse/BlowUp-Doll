using UnityEngine;
using System.Collections;

public class PlayerInputHandler : MonoBehaviour {

    private float right;
    private float jump;
    private float dive;

    public float Right { get { return right; } }
    public float Jump  { get { return jump; } }
    public float Dive { get { return dive; } }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        right = Input.GetAxis("Horizontal");
        jump = Input.GetAxis("Jump");
        dive = Input.GetAxisRaw("Vertical");

	}
}
