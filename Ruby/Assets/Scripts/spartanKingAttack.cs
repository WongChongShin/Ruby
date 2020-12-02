using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spartanKingAttack : MonoBehaviour
{
    public Animator anim;
    private bool collide = true;
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
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        healthPoint.health -= 1;
    }
}
