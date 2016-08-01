using UnityEngine;
using System.Collections;

public class GalController : MonoBehaviour {

    public float speed;
    public float health;
    public Transform fireballpos;
    public GameObject fireball;
    public float firerate;

    private Animator anim;
    private Transform playertransform;
    private Rigidbody mybody;
    private bool isdead;

  
    //private bool iswalking;
    private float nextshoot;
    private float nextwalk;
    private int nextwalktype;
	// Use this for initialization
	void Start () {
        mybody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        //gamecontroller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        playertransform = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(playertransform);

        isdead = false;
        //iswalking = false;
        nextshoot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0 && !isdead)
        {
            isdead = true;
            anim.Play("dying");
        }
        if (isdead)
            return;
        if (Time.time > nextshoot)
        {
            transform.LookAt(playertransform);
            mybody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePosition;
            anim.Play("fireball");
            StartCoroutine(AttackUsingFireBall());
            nextshoot = Time.time + firerate;
            nextwalk = Time.time + 3;
            nextwalktype = Random.Range(0, 3);
            //iswalking = false;
        }
        else if (Time.time > nextwalk /*&& !iswalking*/)
        {
            //iswalking = true;
            /*float dis = Vector3.Distance(transform.position, playertransform.position);
            if(dis < 7)
            {
                anim.Play("walking01");
                mybody.constraints = RigidbodyConstraints.FreezeRotation;
                mybody.velocity = new Vector3(-transform.forward.x, 0, -transform.forward.z) * speed;
            }*/
            if (nextwalktype == 0)
            {
                anim.Play("walking01");
                mybody.constraints = RigidbodyConstraints.FreezeRotation;
                mybody.velocity = new Vector3(transform.forward.x, 0, transform.forward.z) * speed;
            }
            else if (nextwalktype == 1)
            {
                anim.Play("walking02");
                mybody.constraints = RigidbodyConstraints.FreezeRotation;
                mybody.velocity = new Vector3(-transform.forward.x, 0, transform.forward.z) * speed;
            }
            else if (nextwalktype == 2)
            {
                anim.Play("walking02");
                mybody.constraints = RigidbodyConstraints.FreezeRotation;
                mybody.velocity = new Vector3(transform.forward.x, 0, -transform.forward.z) * speed;
            }
            else if (nextwalktype == 3)
            {
                anim.Play("walking01");
                mybody.constraints = RigidbodyConstraints.FreezeRotation;
                mybody.velocity = new Vector3(-transform.forward.x, 0, -transform.forward.z) * speed;
            }
        }
    }

    IEnumerator AttackUsingFireBall()
    {
        yield return new WaitForSeconds(2);
        Instantiate(fireball, fireballpos.position, fireballpos.rotation);
    }
}
