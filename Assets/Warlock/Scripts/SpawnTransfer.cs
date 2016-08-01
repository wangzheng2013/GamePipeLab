using UnityEngine;
using System.Collections;

public class SpawnTransfer : MonoBehaviour {

    private bool IsShoot;
    private GameObject gamecontroller;
    void Start()
    {
        IsShoot = false;
        gamecontroller = GameObject.FindGameObjectWithTag("GameController");
    }

    void Update()
    {
        
    }

    public void AddTransform(GameObject prefab)
    {
        if (IsShoot)
            return;
        GameObject go = GameObject.Instantiate(prefab);
        go.transform.position = transform.position;
        go.transform.localScale = Vector3.one * 0.5f;
        IsShoot = true;
        gamecontroller.GetComponent<GameController>().hastransfer = true;
    }

    public void StopShoot()
    {
        IsShoot = false;
    }
}
