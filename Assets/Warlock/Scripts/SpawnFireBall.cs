using UnityEngine;
using System.Collections;

public class SpawnFireBall : MonoBehaviour {

    private bool IsShoot;
    public Transform Spawntransform;
    private GameObject gamecontroller;
    // Use this for initialization
    void Start() {
        IsShoot = false;
        gamecontroller = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update() {

    }

    public void AddBalls(GameObject prefab)
    {
        if (IsShoot)
            return;
        GameObject go = GameObject.Instantiate(prefab);
        go.transform.parent = transform;
        go.transform.localPosition = Vector3.zero;
        go.transform.localScale = Vector3.one *0.5f;
        go.transform.SetParent(null);
        go.GetComponent<FireballMover>().velocity = new Vector3(Spawntransform.forward.x * 5,0, Spawntransform.forward.z * 5);
        //Debug.Log(palmtransform.forward);
        gamecontroller.GetComponent<GameController>().hasfireball = true;
        IsShoot = true;
    }

    public void StopShoot()
    {
        IsShoot = false;
    }
}
