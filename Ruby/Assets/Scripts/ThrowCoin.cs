using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCoin : MonoBehaviour
{
    public AudioClip throwSound;
    public GameObject CoconutObject;
    public float ThrowForce;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ThrowCoin"))
        {
            GameObject temp = Instantiate(CoconutObject, transform.position, transform.rotation);
            temp.name = "CastFlash";

            if (temp.GetComponent<Rigidbody>() == null)
            {
                Debug.Log("No RigidBody Found!");
                temp.AddComponent<Rigidbody>();
            }

            Rigidbody rb = temp.GetComponent<Rigidbody>();
            rb.velocity = transform.TransformDirection(new Vector3(0, 0, ThrowForce));
            audio.clip = throwSound;
            audio.Play();
        }
    }
}
