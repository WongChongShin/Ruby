using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidePlayer : MonoBehaviour
{
    public Animator anim;
    public TimeManager timeManager;
    public bool slowMotionPeriod = false;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision colliderInfo)
    {
        if (colliderInfo.gameObject.tag == "Player")
        {
            if ((anim.GetBool("isAttack") == true || anim.GetBool("isSlay") == true) && RubyDodge.isDodge == false)
            {
                StartCoroutine(wait());
            }
            else if ((anim.GetBool("isAttack") == true || anim.GetBool("isSlay") == true) && RubyDodge.isDodge == true)
            {
                slowMotionPeriod = true;

                if (slowMotionPeriod == true)
                {
                    Debug.Log("is slow down!!");
                    timeManager.DoSlow();
                    StartCoroutine(wait2());
                }
               

                
            }

        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        healthPoint.health -= 1;
    }

    IEnumerator wait2()
    {
        yield return new WaitForSeconds(2);
        RubyDodge.isDodge = false;
        slowMotionPeriod = false;
    }
}
