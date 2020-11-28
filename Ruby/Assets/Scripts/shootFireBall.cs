using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shootFireBall : MonoBehaviour
{
    public GameObject fireball;
    public Transform player;
    public GameObject aimUI;
    public GameObject fps;
    private bool aim=false;
    private bool checkAim = false;
    public float throwForce;
    // Start is called before the first frame update
    void Start()
    {
        fireball.GetComponent<ParticleSystem>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (aim ==true)
        {
            controlCannon();
        }
    }
    void OnTriggerEnter(Collider collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Player")
        {
            aim = true;
        }
        else
        {
            aim = false;
        }
    }
    void controlCannon()
    {
        if (Input.GetButtonDown("equip cannon"))
        {
            if (checkAim == false)
            {
                
                (player.GetComponent<Animator>()).enabled = false;
                //aimUI.SetActive(true);
                checkAim = true;
            }
            else
            {
                (player.GetComponent<Animator>()).enabled = true;
                //aimUI.SetActive(false);
                checkAim = false;
            }
        }
        if (checkAim == true)
        {
            mouseMovement();
            shoot();
        }
        else
        {
            fps.SetActive(false);
        }
    }
    void mouseMovement()
    {
        fps.SetActive(true);
        (transform.GetComponent("FirstPersonController") as MonoBehaviour).enabled = true;

    }
    void shoot()
    {
        if (Input.GetButtonDown("shoot"))
        {
            Vector3 createPosition = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
            GameObject temp = Instantiate(fireball, createPosition, transform.rotation);

            if (temp.GetComponent<Rigidbody>() == null)
            {
                Debug.Log("no Rigidbody found!");
                temp.AddComponent<Rigidbody>();
                temp.AddComponent<destroyFireBall>();
            }
            Rigidbody rb = temp.GetComponent<Rigidbody>();
            rb.velocity = fireball.transform.TransformDirection(new Vector3(0, 0, throwForce));
        }
    }
}
