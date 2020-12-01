using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class paladinDetectTarget : MonoBehaviour
{
    public Transform Enemy;
    public Animator anim;
    public int speed;
    private paladdinMove movePaladdin;
    private Vector3 myCharacter;
    private Vector3 targetEnemy;
    private NavMeshAgent agent;
    private bool die = false;
    public AudioClip targetDetect;
    public AudioClip enemyDieSound;
    private CapsuleCollider collider;
    private bool attack = false;
    private bool detectAudio = false;

    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        movePaladdin = gameObject.GetComponent<paladdinMove>();
        audio = GetComponent<AudioSource>();
        collider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        detectionChecker();
    }
    void changeAnimation()
    {
        if (Vector3.Distance(myCharacter, targetEnemy) <= 70 && Vector3.Distance(myCharacter, targetEnemy) > 31)
        {
            collider.radius = 0.45f;
            agent.isStopped = false;
            anim.SetBool("isWalk", false);
            anim.SetBool("isChase", true);
            anim.SetBool("isSlay", false);
            anim.SetBool("isAttack", false);
        }
        else if (Vector3.Distance(myCharacter, targetEnemy) <= 30 && Vector3.Distance(myCharacter, targetEnemy) > 17)
        {
            if (attack == false)
            {
                collider.radius = 2.0f;
                agent.isStopped = true;
                anim.SetBool("isWalk", false);
                anim.SetBool("isChase", false);
                anim.SetBool("isSlay", false);
                anim.SetBool("isAttack", true);
                attack = true;
                StartCoroutine(wait2());
            }
        }
        else if (Vector3.Distance(myCharacter, targetEnemy) <= 16)
        {

            if (attack == false)
            {
                collider.radius = 1.0f;
                agent.isStopped = true;
                anim.SetBool("isChase", false);
                anim.SetBool("isWalk", false);
                anim.SetBool("isAttack", false);
                anim.SetBool("isSlay", true);
                attack = true;
                StartCoroutine(wait2());
            }

        }
    }
    public void detectionChecker()
    {
        if (die == true)
        {
            anim.SetBool("isWalk", false);
            anim.SetBool("isChase", false);
            anim.SetBool("isSlay", false);
            anim.SetBool("isAttack", false);
            anim.SetBool("isObserve", false);

        }
        else
        {
            myCharacter = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            targetEnemy = new Vector3(Enemy.position.x, Enemy.position.y, Enemy.position.z);
            if (Vector3.Distance(myCharacter, targetEnemy) <= 70 && Vector3.Distance(myCharacter, targetEnemy) > 5)
            {
                agent.isStopped = false;
                if (detectAudio == false)
                {
                    detectAudio = true;
                    audio.clip = targetDetect;
                    audio.Play();
                }
                transform.LookAt(targetEnemy);
                //transform.position += transform.forward * Time.deltaTime * speed;
                agent.destination = targetEnemy;
                (transform.GetComponent("paladdinMove") as MonoBehaviour).enabled = false;
                changeAnimation();

            }
            else if (Vector3.Distance(myCharacter, targetEnemy) > 70)
            {
                detectAudio = false;
                agent.isStopped = true;
                collider.radius = 0.45f;
                (transform.GetComponent("paladdinMove") as MonoBehaviour).enabled = true;
                movePaladdin.movement();
            }
        }
    }
    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "box" || collisionInfo.gameObject.tag == "explosion")
        {
            anim.SetBool("isDie", true);
            die = true;
            StartCoroutine(wait());
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        audio.clip = enemyDieSound;
        audio.Play();
        Destroy(gameObject, 3);

    }

    IEnumerator wait2()
    {
        yield return new WaitForSeconds(2);
        anim.SetBool("isAttack", false);
        anim.SetBool("isSlay", false);
        //collider.radius = 0.45f;
        StartCoroutine(wait3());


    }
    IEnumerator wait3()
    {
        yield return new WaitForSeconds(2);
        attack = false;
    }
}
