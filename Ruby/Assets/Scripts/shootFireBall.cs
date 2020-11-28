using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shootFireBall : MonoBehaviour
{
    public GameObject fireball;
    public Transform player;
    public GameObject aimUI;
    // Start is called before the first frame update
    void Start()
    {
        //aimUI = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        fireball.GetComponent<ParticleSystem>().Play();
    }
    void OnTriggerEnter(Collider collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Player")
        {
            aimUI.SetActive(true);
            if (Input.GetButtonDown("equip cannon"))
            {
                print("here");
                controlCannon();
            }
        }
    }
    void controlCannon()
    {
        aimUI.SetActive(false);
    }
}
