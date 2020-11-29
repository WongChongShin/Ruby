using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidePlayer : MonoBehaviour
{
    public Animator anim;
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
            if (anim.GetBool("isAttack") == true || anim.GetBool("isSlay")== true)
            {
                StartCoroutine(wait());
            }

        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        healthPoint.health -= 1;
    }
}
