using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightningVltAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision colliderInfo)
    {
        if (colliderInfo.gameObject.tag == "Player")
        {
                StartCoroutine(wait());
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        healthPoint.health -= 1;
    }
}
