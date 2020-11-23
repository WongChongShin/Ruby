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
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        moveSpartanKing = gameObject.GetComponent<spartanKingMove>();
    }

    // Update is called once per frame
    void Update()
    {
        detectionChecker();
    }
    void changeAnimation()
    {
        if (Vector3.Distance(myCharacter, targetEnemy) <= 100 && Vector3.Distance(myCharacter, targetEnemy) > 31)
        {

            anim.SetBool("isWalking", false);
            anim.SetBool("isCharge", true);
            anim.SetBool("isAttack", false);
        }
        else if (Vector3.Distance(myCharacter, targetEnemy) <= 30 && Vector3.Distance(myCharacter, targetEnemy) > 17)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isCharge", false);
            anim.SetBool("isAttack", true);
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
            moveSpartanKing.movement();
        }
    }
}
