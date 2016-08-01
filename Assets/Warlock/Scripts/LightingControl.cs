using UnityEngine;
using System.Collections;

public class LightingControl : MonoBehaviour {

    private Rigidbody rb;
    private Transform SpawnTransform;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SpawnTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(SpawnTransform.forward.x * 5, 0, SpawnTransform.forward.z * 5) * 5;
    }
}
