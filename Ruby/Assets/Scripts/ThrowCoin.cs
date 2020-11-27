using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCoin : MonoBehaviour
{
    public AudioClip throwSound;
    public GameObject objectThrow;
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
            Debug.Log("Coin has been thrown");
            Instantiate(objectThrow, transform.position, transform.rotation);
            

            //if (temp.GetComponent<Rigidbody>() == null)
            //{
            //    Debug.Log("No RigidBody Found!");
            //    AddComponent<Rigidbody>();
            //}

            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = transform.TransformDirection(new Vector3(0, 0, ThrowForce));
            audio.clip = throwSound;
            audio.Play();
        }
    }
}
