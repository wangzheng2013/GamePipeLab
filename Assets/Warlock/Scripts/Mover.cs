using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float speed;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().velocity = new Vector3(transform.forward.x,0,transform.forward.z) * speed;
	}
}
