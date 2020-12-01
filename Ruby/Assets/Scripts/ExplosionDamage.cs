using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
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
            Debug.Log("Bomb Damaged!");
            healthPoint.health -= 1;
            Destroy(gameObject);
        }
    }
}
