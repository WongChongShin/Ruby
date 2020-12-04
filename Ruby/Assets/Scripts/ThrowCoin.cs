using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCoin : MonoBehaviour
{
    public AudioClip throwSound;
    public GameObject objectThrow;
    public float ThrowForce;
    private AudioSource audio;

    //teleport
    public GameObject player;
    private int coinNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ThrowCoin") && ShadowCoinCollect.numOfCoin >= 5)
        {
            if(coinNum == 0)
            {
                coinNum += 1;
                StartCoroutine(wait());
            }
        }
        
        IEnumerator wait()
        {
            
            yield return new WaitForSeconds(1);
            GameObject temp = Instantiate(objectThrow, transform.position, transform.rotation);
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
            StartCoroutine(wait2());

            IEnumerator wait2()
            {
                yield return new WaitForSeconds(2);
                player.transform.position = new Vector3(temp.transform.position.x, temp.transform.position.y+10, temp.transform.position.z);
                coinNum = 0;
            }
            ShadowCoinCollect.numOfCoin -= 5;
        }
    }
}
