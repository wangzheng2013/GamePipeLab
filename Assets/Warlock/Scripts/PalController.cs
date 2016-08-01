using UnityEngine;
using System.Collections;

public class PalController : MonoBehaviour {

    public float speed;
    public int health;
    public float attackrate;

    private Animator anim;
    private Rigidbody rbody;
    private Transform playertransform;
    private GameController gamecontroller;
    private AudioSource swordaudio;
    private NavMeshAgent nav;

    private bool iswalking;
    private bool isdead;

    private float n_time;
    private float recover_time;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        swordaudio = GetComponent<AudioSource>();
        nav = GetComponent<NavMeshAgent>();
        gamecontroller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        playertransform = GameObject.FindGameObjectWithTag("Player").transform;
        nav.SetDestination(playertransform.position);

        iswalking = true;
        isdead = false;
        n_time = 0;
        recover_time = 0;
    }
	
	// Update is called once per frame
	void Update () {
        float dis = Vector3.Distance(transform.position, playertransform.position);

        if (health == 0 && !isdead)
        {
            anim.Play("dead");
            Destroy(gameObject, 5);
            isdead = true;
        }
        if (isdead)
            return;
        if (iswalking)
        {
            playertransform = GameObject.FindGameObjectWithTag("Player").transform;
            nav.SetDestination(playertransform.position);
            swordaudio.Stop();
        }
        if (dis < 3)
        {
            if (Time.time > n_time)
            {
                iswalking = false;
                anim.Play("slash");
                swordaudio.PlayDelayed(0.3f);
                gamecontroller.playerlife--;
                n_time = Time.time + attackrate;
            }
        }
        else
        {
            iswalking = true;
        }
        if(Time.time > recover_time)
        {
            nav.speed = 2;
            rbody.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "fireball")
        {
            rbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            nav.speed = 0;
            recover_time = Time.time + 1;
        }
    }
}
