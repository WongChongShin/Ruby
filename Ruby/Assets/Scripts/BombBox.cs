using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBox : MonoBehaviour
{
    //public float delay = 1f;
    //float countDown;
    //bool hasExploded = false;
    //public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        //countDown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;

        //if (Physics.Raycast(transform.position, transform.forward, out hit, 2.0f))
        //{
        //    if (hit.collider.gameObject.tag == "Player")
        //    {
        //        countDown -= Time.deltaTime;
        //        if (countDown <= 0f && !hasExploded)
        //        {
        //            Debug.Log("Boom!");
        //            Instantiate(explosionEffect, transform.position, transform.rotation);
        //            Destroy(gameObject);
        //            hasExploded = true;
        //        }
        //    }
        //}
    }
}
