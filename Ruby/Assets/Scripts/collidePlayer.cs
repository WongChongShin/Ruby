using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidePlayer : MonoBehaviour
{
    public Animator anim;
    private bool collide=true;
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
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
            {
                if (collide == true)
                {
                    collide = false;
                    StartCoroutine(wait());
                }
            }
            else if(anim.GetCurrentAnimatorStateInfo(0).IsName("slay"))
            {
                if (collide == true)
                {
                    collide = false;
                    StartCoroutine(wait2());
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
    void collideHP()
    {
        healthPoint.health -= 1;
        collide = true;
    }
}
