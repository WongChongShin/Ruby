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
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        movePaladdin = gameObject.GetComponent<paladdinMove>();
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
        if (Vector3.Distance(myCharacter, targetEnemy) <= 70 && Vector3.Distance(myCharacter, targetEnemy) > 5)
        {
            transform.LookAt(targetEnemy);
            transform.position += transform.forward * Time.deltaTime * speed;
            if (Vector3.Distance(myCharacter, targetEnemy) <= 70 && Vector3.Distance(myCharacter, targetEnemy) > 7)
            {
                paladdinMove.agent.isStopped = true;
            }
            changeAnimation();

        }
        else if (Vector3.Distance(myCharacter, targetEnemy) > 70)
        {
            paladdinMove.agent.isStopped = false;
            movePaladdin.movement();
        }
    }
}
