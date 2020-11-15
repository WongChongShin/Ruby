using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class paladinDetectTarget : MonoBehaviour
{
    public Transform Enemy;
    public Animator anim;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 myCharacter = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 targetEnemy = new Vector3(Enemy.position.x, Enemy.position.y, Enemy.position.z);
        if (Vector3.Distance(myCharacter, targetEnemy) <= 50 && Vector3.Distance(myCharacter, targetEnemy) > 41)
        {
            anim.SetBool("isWalk", false);
            anim.SetBool("isChase", true);
        }
        else if (Vector3.Distance(myCharacter, targetEnemy) <= 40 && Vector3.Distance(myCharacter, targetEnemy) > 21)
        {
            anim.SetBool("isChase", false);
            anim.SetBool("isAttack", true);
        }
        else if (Vector3.Distance(myCharacter, targetEnemy) <= 20 && Vector3.Distance(myCharacter, targetEnemy) > 11)
        {
            anim.SetBool("isAttack", false);
            anim.SetBool("isSlay", true);
        }
        if (Vector3.Distance(myCharacter, targetEnemy) <= 50 && Vector3.Distance(myCharacter, targetEnemy) > 11)
        {
            transform.LookAt(targetEnemy);
            transform.position += transform.forward * Time.deltaTime * speed;
            paladdinMove.noEnermy = false;
        }
        else if (Vector3.Distance(myCharacter, targetEnemy) > 50)
        {
            paladdinMove.noEnermy = true;
        }
    }
}
