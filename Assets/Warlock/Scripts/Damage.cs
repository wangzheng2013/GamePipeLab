using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

    public GameObject explosion;
    private GameObject gamecontroller;
	// Use this for initialization
	void Start () {
        gamecontroller = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            gamecontroller.GetComponent<GameController>().playerlife--;
            if(tag == "EShoot")
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "fireball")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(col.gameObject);
        }

    }
}
