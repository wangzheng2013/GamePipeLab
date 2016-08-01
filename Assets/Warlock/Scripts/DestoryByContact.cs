using UnityEngine;
using System.Collections;

public class DestoryByContact : MonoBehaviour {

    public GameObject explosion;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Wall")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if(col.gameObject.tag == "PalEnemy")
        {
            col.gameObject.GetComponent<PalController>().health--;
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "ArEnemy")
        {
            col.gameObject.GetComponent<ArcherController>().health--;
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if(col.gameObject.tag == "GalEnemy")
        {
            col.gameObject.GetComponent<GalController>().health--;
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
