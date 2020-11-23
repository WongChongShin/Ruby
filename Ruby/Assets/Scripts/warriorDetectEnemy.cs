using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class warriorDetectEnemy : MonoBehaviour
{
    public Transform Enemy;
    public Animator anim;
    public int speed;
    private warriorMove moveWarrior;
    private Vector3 myCharacter;
    private Vector3 targetEnemy;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        moveWarrior = gameObject.GetComponent<warriorMove>();
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

            anim.SetBool("isWalking", true);
            anim.SetBool("isAttack1", false);
            anim.SetBool("isAttack2", false);
        }
        else if (Vector3.Distance(myCharacter, targetEnemy) <= 30 && Vector3.Distance(myCharacter, targetEnemy) > 17)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttack1", true);
            anim.SetBool("isAttack2", false);
        }
        else if (Vector3.Distance(myCharacter, targetEnemy) <= 16 && Vector3.Distance(myCharacter, targetEnemy) > 5)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttack1", false);
            anim.SetBool("isAttack2", true);
        }
    }
    public void detectionChecker()
    {
        myCharacter = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        targetEnemy = new Vector3(Enemy.position.x, Enemy.position.y, Enemy.position.z);
        if (Vector3.Distance(myCharacter, targetEnemy) <= 70 && Vector3.Distance(myCharacter, targetEnemy) > 5)
        {
            transform.LookAt(targetEnemy);
            transform.position += transform.forward * Time.deltaTime * speed;
            if (Vector3.Distance(myCharacter, targetEnemy) <= 70 && Vector3.Distance(myCharacter, targetEnemy) > 7)
            {
                agent.isStopped = true;
            }
            changeAnimation();

        }
        else if (Vector3.Distance(myCharacter, targetEnemy) > 70)
        {
            agent.isStopped = false;
            moveWarrior.movement();
        }
    }
}
