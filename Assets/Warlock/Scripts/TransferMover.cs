using UnityEngine;
using System.Collections;

public class TransferMover : MonoBehaviour {

    private GameObject Player;
    private Vector3 SpawnPosition;
    public float speed;
    private float starttime;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        SpawnPosition = GameObject.FindGameObjectWithTag("Index").transform.forward;
        if (SpawnPosition.y < 0.5)
            SpawnPosition.y = 0.5f;
        //Debug.Log(SpawnPosition);
        GetComponent<Rigidbody>().velocity = SpawnPosition * speed;
        starttime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        if(Time.time < starttime + 0.2f)
            GetComponent<Rigidbody>().velocity = SpawnPosition * speed;
    }


    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Ground")
        {
            Player.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
