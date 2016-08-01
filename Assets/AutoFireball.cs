using UnityEngine;
using System.Collections;

public class AutoFireball : MonoBehaviour {

    public float speed;
    private Transform playertransform;
    private Vector3 v;
    private Rigidbody rbody;
	// Use this for initialization
	void Start () {
        playertransform = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(playertransform);
        v = new Vector3(transform.forward.x, 0, transform.forward.z) * speed;
        rbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rbody.velocity = v;
	}
}
