using UnityEngine;
using System.Collections;

public class ArcherController : MonoBehaviour {

    public int health;
    public Transform shootpos;
    public GameObject arrow;
    public float firerate;

    private Animator anim;
    private Transform playertransform;
    private AudioSource arrowaudio;
    //private GameController gamecontroller;

    private bool isdead;
    private float ntime;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        arrowaudio = GetComponent<AudioSource>();
        //gamecontroller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        playertransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        transform.LookAt(playertransform);

        isdead = false;
        ntime = 0;
    }

    void Update()
    {
        if (health == 0 && !isdead)
        {
            isdead = true;
            anim.Play("dead");
            Destroy(gameObject, 5);
        }
        if (isdead)
            return;

        if(ntime < Time.time)
        {
            Shoot();
            ntime = Time.time + firerate;
        }
    }

    void Shoot()
    {
        anim.Play("arrow");
        arrowaudio.Play();
        Instantiate(arrow, shootpos.position, shootpos.rotation);
    }

}
