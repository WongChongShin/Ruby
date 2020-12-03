using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recover : MonoBehaviour
{
    bool recover = false;
    public float rotationAmount = 3.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            transform.Rotate(0.0f, 0.0f, rotationAmount);
     
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player")
        {
            if(healthPoint.health < 3)
            {
                
                healthPoint.health += 1;
                Destroy(gameObject);
            }
        }
    }
}
