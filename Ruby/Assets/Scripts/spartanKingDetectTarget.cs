using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class spartanKingDetectTarget : MonoBehaviour
{
    public Transform Enemy;
    public Animator anim;
    public int speed;
    private spartanKingMove moveSpartanKing;
    private Vector3 myCharacter;
    private Vector3 targetEnemy;
    private NavMeshAgent agent;
    public GameObject electricalVolt;
    private bool particleOn = false;
    private bool startChase = false;
    public Transform[] door;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GetComponent<NavMeshAgent>().speed = speed;
        anim = GetComponent<Animator>();
        moveSpartanKing = gameObject.GetComponent<spartanKingMove>();
    }

    // Update is called once per frame
    void Update()
    {
        getDoorPosition();
        detectionChecker();
    }
    void changeAnimation()
    {
        
        if (Vector3.Distance(myCharacter, targetEnemy) <= 49 && Vector3.Distance(myCharacter, targetEnemy) > 0)
        {
            agent.isStopped = true;
            anim.SetBool("isWalking", false);
            anim.SetBool("isCharge", false);
            anim.SetBool("isAttack", true);
        }
        else
        {
            if (!electricalVolt.GetComponent<ParticleSystem>().isPlaying)
            {
                agent.isStopped = false;
                anim.SetBool("isWalking", false);
                anim.SetBool("isCharge", true);
                anim.SetBool("isAttack", false);
            }
            else
            {
                agent.isStopped = true;
                anim.SetBool("isWalking", false);
                anim.SetBool("isCharge", false);
                anim.SetBool("isAttack", false);
            }
        }
    }
    public void detectionChecker()
    {
        myCharacter = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        targetEnemy = new Vector3(Enemy.position.x, Enemy.position.y, Enemy.position.z);
        if (startChase == true)
        {
            if (Vector3.Distance(myCharacter, targetEnemy) > 15)
            {
                if (!electricalVolt.GetComponent<ParticleSystem>().isPlaying)
                {
                    transform.LookAt(targetEnemy);
                    agent.destination=targetEnemy;
                }
            }
            changeAnimation();
            if (Vector3.Distance(myCharacter, targetEnemy) >49)
            {
                if (particleOn == false)
                {
                    particleOn = true;
                    StartCoroutine(wait1());
                }
            }

        }
    }
    void electronicCreate()
    {
        if (electricalVolt.GetComponent<ParticleSystem>().isPlaying)
        {
            electricalVolt.GetComponent<ParticleSystem>().Stop();
            particleOn = false;
        }
        else
        {
            electricalVolt.GetComponent<ParticleSystem>().Play();
            particleOn = false;
        }
    }
    IEnumerator wait1()
    {
        yield return new WaitForSeconds(5);
        electronicCreate();
    }
    void getDoorPosition()
    {
        for (int i = 0; i < door.Length; i++)
        {
            if (door[i].position.y > 70)
            {
                startChase = true;

            }
        }
    }
}
