using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBox : MonoBehaviour
{
    public float delay = 1f;
    float countDown;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 2.0f))
        {
            if (hit.collider.gameObject.tag == "Player")
            {

                countDown -= Time.deltaTime;
                if (countDown <= 0f)
                {
                    Debug.Log("Boom!");
                }
            }
        }
    }
}
