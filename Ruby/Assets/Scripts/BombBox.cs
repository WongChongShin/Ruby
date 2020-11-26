using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBox : MonoBehaviour
{
    bool hasExploded = false;
    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 2.0f) && hit.collider.gameObject.tag == "Player")
        {
            Debug.Log("Boom!");
            StartCoroutine(wait());

            IEnumerator wait()
            {
                yield return new WaitForSeconds(1);
                Instantiate(explosionEffect, transform.position, transform.rotation);
                Destroy(gameObject);
                hasExploded = true;
            }

        }
    }
}
