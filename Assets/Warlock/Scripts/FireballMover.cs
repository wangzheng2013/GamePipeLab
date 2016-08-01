using UnityEngine;
using System.Collections;

public class FireballMover : MonoBehaviour {

    private Rigidbody rb;
    public Vector3 velocity;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = velocity*5;
	}
}
