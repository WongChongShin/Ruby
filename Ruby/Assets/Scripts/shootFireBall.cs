using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shootFireBall : MonoBehaviour
{
    public GameObject[] powerball;
    private int change = 0;
    public Transform player;
    public GameObject aimUI;
    public GameObject firstPersonCamera;
    public GameObject thirdPersonCamera;
    private bool aim=false;
    private bool checkAim = false;
    public float throwForce;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            powerball[i].GetComponent<ParticleSystem>().Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (aim ==true)
        {
            controlCannon();
            changePowerBall();
        }
        
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Player")
        {
            aim = true;
        }
    }
    void controlCannon()
    {
        if (Input.GetButtonDown("equip cannon"))
        {
            //press e function
            if (checkAim == false)
            {
                
                (player.GetComponent<Animator>()).enabled = false;
                //aimUI.SetActive(true);
                firstPersonCamera.SetActive(true);
                thirdPersonCamera.SetActive(false);
                (transform.GetComponent("FirstPersonController") as MonoBehaviour).enabled = true;
                checkAim = true;
                aim = false;

            }
            else
            {
                (player.GetComponent<Animator>()).enabled = true;
                //aimUI.SetActive(false);
                firstPersonCamera.SetActive(false);
                thirdPersonCamera.SetActive(true);
                (transform.GetComponent("FirstPersonController") as MonoBehaviour).enabled = false;
                checkAim = false;
                aim = false;
            }
        }
    }

    void changePowerBall()
    {
        if (Input.GetButtonDown("changeball"))
        {
            change++;
            if (change > 2)
            {
                change = 0;
            }
        }
        if (checkAim == true)
        {
            if (Input.GetButtonDown("shoot"))
            {
                if (change == 0)
                {
                    green_power_ball();
                }
                else if (change == 1)
                {
                    red_power_ball();
                }
                else if (change == 2)
                {
                    blue_power_ball();
                }
            }
        }
    }
    void green_power_ball()
    {
        if (greenBallCollect.numGreenBall > 0)
        {
            Vector3 createPosition = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
            GameObject temp = Instantiate(powerball[0], createPosition, transform.rotation);
            temp.SetActive(true);

            if (temp.GetComponent<Rigidbody>() == null)
            {
                temp.AddComponent<Rigidbody>();
            }
            temp.AddComponent<destroyFireBall>();
            Rigidbody rb = temp.GetComponent<Rigidbody>();
            rb.velocity = powerball[0].transform.TransformDirection(new Vector3(0, 0, throwForce));
            temp.GetComponent<SphereCollider>().enabled = true;
            greenBallCollect.numGreenBall--;
            greenBallCollect.textOn = true;
        }
    }

    void red_power_ball()
    {
        if (redBallCollect.numRedBall > 0)
        {
            Vector3 createPosition = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
            GameObject temp = Instantiate(powerball[2], createPosition, transform.rotation);
            temp.SetActive(true);

            if (temp.GetComponent<Rigidbody>() == null)
            {
                temp.AddComponent<Rigidbody>();
            }
            temp.AddComponent<destroyFireBall>();
            Rigidbody rb = temp.GetComponent<Rigidbody>();
            rb.velocity = powerball[2].transform.TransformDirection(new Vector3(0, 0, throwForce));
            temp.GetComponent<SphereCollider>().enabled = true;
            redBallCollect.numRedBall--;
            redBallCollect.textOn = true;
        }
    }
    void blue_power_ball()
    {
        if (blueBallCollect.numBlueBall > 0)
        {
            Vector3 createPosition = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
            GameObject temp = Instantiate(powerball[1], createPosition, transform.rotation);
            temp.SetActive(true);

            if (temp.GetComponent<Rigidbody>() == null)
            {
                temp.AddComponent<Rigidbody>();
            }
            temp.AddComponent<destroyFireBall>();
            Rigidbody rb = temp.GetComponent<Rigidbody>();
            rb.velocity = powerball[1].transform.TransformDirection(new Vector3(0, 0, throwForce));
            temp.GetComponent<SphereCollider>().enabled = true;
            blueBallCollect.numBlueBall--;
            blueBallCollect.textOn = true;
        }

    }
}
