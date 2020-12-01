using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidePlayer : MonoBehaviour
{
    public Animator anim;
    private bool collide = true;
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
    void OnCollisionStay(Collision colliderInfo)
    {
        if (colliderInfo.gameObject.tag == "Player")
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("attack") && RubyDodge.isDodge == false)
            {
                if (collide == true)
                {
                    collide = false;
                    StartCoroutine(wait());
                }
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("slay") && RubyDodge.isDodge == false)
            {
                if (collide == true)
                {
                    collide = false;
                    StartCoroutine(wait2());
                }
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("attack") || anim.GetCurrentAnimatorStateInfo(0).IsName("slay") && RubyDodge.isDodge == true)
            {
                slowMotionPeriod = true;

                if (slowMotionPeriod == true)
                {
                    timeManager.DoSlow();
                    StartCoroutine(wait3());
                }
            }
        }
    }
    void OnCollisionExit()
    {
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(3.4f);
        collideHP();
    }
    IEnumerator wait2()
    {
        yield return new WaitForSeconds(3.2f);
        collideHP();
    }
    IEnumerator wait3()
    {
        yield return new WaitForSeconds(2);
        RubyDodge.isDodge = false;
        slowMotionPeriod = false;
    }
    void collideHP()
    {
        healthPoint.health -= 1;
        collide = true;
    }
}
