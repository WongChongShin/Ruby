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
    public static bool die = false;

    public AudioClip enemyDieSound;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        movePaladdin = gameObject.GetComponent<paladdinMove>();
        audio = GetComponent<AudioSource>();
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

            anim.SetBool("isWalk", false);
            anim.SetBool("isChase", true);
            anim.SetBool("isSlay", false);
            anim.SetBool("isAttack", false);
        }
        else if (Vector3.Distance(myCharacter, targetEnemy) <= 30 && Vector3.Distance(myCharacter, targetEnemy) > 17)
        {
            anim.SetBool("isWalk", false);
            anim.SetBool("isChase", false);
            anim.SetBool("isSlay", false);
            anim.SetBool("isAttack", true);
        }
        else if (Vector3.Distance(myCharacter, targetEnemy) <= 16 && Vector3.Distance(myCharacter, targetEnemy) > 5)
        {
            anim.SetBool("isChase", false);
            anim.SetBool("isWalk", false);
            anim.SetBool("isAttack", false);
            anim.SetBool("isSlay", true);
        }
    }
    public void detectionChecker()
    {
            myCharacter = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            targetEnemy = new Vector3(Enemy.position.x, Enemy.position.y, Enemy.position.z);
        if (die==true) {
            movePaladdin.agent.isStopped = true;
            anim.SetBool("isWalk", false);
            anim.SetBool("isChase", false);
            anim.SetBool("isSlay", false);
            anim.SetBool("isAttack", false);
            anim.SetBool("isObserve", false);
            anim.SetBool("isDie", true);
        }
        else {
            if (Vector3.Distance(myCharacter, targetEnemy) <= 70 && Vector3.Distance(myCharacter, targetEnemy) > 5)
            {
                transform.LookAt(targetEnemy);
                transform.position += transform.forward * Time.deltaTime * speed;
                if (Vector3.Distance(myCharacter, targetEnemy) <= 70 && Vector3.Distance(myCharacter, targetEnemy) > 7)
                {
                    movePaladdin.agent.isStopped = true;
                }
                changeAnimation();

            }
            else if (Vector3.Distance(myCharacter, targetEnemy) > 70)
            {
                movePaladdin.agent.isStopped = false;
                movePaladdin.movement();
            }
        }
    }
    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "box")
        {
            die = true;
            StartCoroutine(wait());
            
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        audio.clip = enemyDieSound;
        audio.Play();
        Destroy(gameObject, 3);
    }
}
