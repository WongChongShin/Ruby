using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class paladdinDie : MonoBehaviour
{
    private paladdinMove movePaladdin;
    public Animator anim;
    public AudioClip enemyDieSound;
    public static bool die=true;
    private NavMeshAgent agent;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        movePaladdin = gameObject.GetComponent<paladdinMove>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (die == true)
        {
            movePaladdin.agent.isStopped = true;
            anim.SetBool("isWalk", false);
            //anim.SetBool("isChase", false);
            //anim.SetBool("isSlay", false);
            //anim.SetBool("isAttack", false);
            //anim.SetBool("isObserve", false);
            anim.SetBool("isDie", true);
        }
    }
    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "box")
        {
            
            enemyDie();
        }
    }
    public void enemyDie()
    {
        audio.clip = enemyDieSound;
            audio.Play();
            Destroy(gameObject, 3);
    }
}
