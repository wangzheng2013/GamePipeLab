using UnityEngine;
using System.Collections;

public class SpawnThunder : MonoBehaviour {

    public GameObject Thunder;
    private IEnumerator _spawnCoroutine;
    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Awake()
    {
        _spawnCoroutine = StartSpawn(Thunder);
    }

    public void Startthunder()
    {
        StartCoroutine(_spawnCoroutine);
    }

    public void Stopthunder()
    {
        StopAllCoroutines();
    }

    public IEnumerator StartSpawn(GameObject prefab)
    {
        while (true)
        {
            SpawnThunders(prefab);
            yield return new WaitForSeconds(1f);
        }
    }

    public void SpawnThunders(GameObject prefab)
    {
        GameObject go = GameObject.Instantiate(prefab);
        go.transform.position = transform.position;
        go.transform.localScale = Vector3.one * 0.5f;
    }
}
