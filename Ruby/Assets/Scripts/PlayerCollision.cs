using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    //Ruby Die and collect coin declaration
    private bool rubyIsDead = false;
    public AudioClip rubyDieSound;   
    public AudioClip coinIsCollected;
    public Animator anim;

    public int numOfKey = 0;
    static public bool doorOpen = false;

    //Collide Bomb declare
    public float delay = 1f;
    float countDown;
    bool hasExploded = false;
    public GameObject explosionEffect;

    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

        //Collide bomb starting assign
       countDown = delay;

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 2.0f))
        {
            //Collide trap
            if (hit.collider.gameObject.tag == "Trap" && rubyIsDead == false)
            {
                Debug.Log("Game Over!");
                rubyDead(rubyDieSound, true);
            }
            //Collide locked door
            else if (hit.collider.gameObject.tag == "LockedDoor" && rubyIsDead == false)
            {
                Debug.Log("Opening!");
                if (numOfKey > 0)
                {
                    doorOpen = true;
                }
            }

            //Collide Bomb

        }
    }


    //Ruby dead event
    void rubyDead(AudioClip rubyDieSound, bool checkDead)
    {
        anim.SetBool("IsDead", true);
        audio.clip = rubyDieSound;
        audio.Play();      
        rubyIsDead = checkDead;

    }

    //Ruby collect coin
    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Coin")
        {
            audio.clip = coinIsCollected;
            audio.Play();
            ShadowCoinCollect.numOfCoin++;
            Destroy(collisionInfo.gameObject);
            ShadowCoinCollect.textOn = true;
        }

        else if (collisionInfo.gameObject.tag == "Key")
        {
            Debug.Log("Key get!");
            audio.clip = coinIsCollected;
            audio.Play();
            numOfKey++;
            Destroy(collisionInfo.gameObject);
        }
    }
}