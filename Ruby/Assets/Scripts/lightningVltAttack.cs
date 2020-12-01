using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightningVltAttack : MonoBehaviour
{
    private bool collide=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnParticleCollision(GameObject colliderInfo)
    {
        if (colliderInfo.tag == "Player")
        {
            if (collide == false)
            {
                StartCoroutine(wait());
            }
        }
    }
    IEnumerator wait()
    {
        collide = true;
        yield return new WaitForSeconds(1.5f);
        healthPoint.health -= 1;
        collide = false;
    }
}
