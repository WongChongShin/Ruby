using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBox : MonoBehaviour
{
    bool hasExploded = false;
    public GameObject explosionEffect;
    public GameObject bomb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider collisionInfo)
    {
         if (collisionInfo.gameObject.tag == "Player")
                {
                    Debug.Log("Boom!");
                    StartCoroutine(wait());
                }

                IEnumerator wait()
                {
                    yield return new WaitForSeconds(1);
                    Instantiate(explosionEffect, transform.position, transform.rotation);
                    Destroy(bomb);
                    hasExploded = true;
                }
    }
}
