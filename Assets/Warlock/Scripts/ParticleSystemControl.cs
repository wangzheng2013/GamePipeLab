using UnityEngine;
using System.Collections;

public class ParticleSystemControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<ParticleSystem>().Simulate(2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
