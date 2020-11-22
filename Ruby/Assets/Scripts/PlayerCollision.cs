using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private bool rubyIsDead = false;
    private int shadowCoin = 0;
    public AudioClip rubyDieSound;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 2.0f))
        {
            if (hit.collider.gameObject.tag == "Trap" && rubyIsDead == false)
            {
                Debug.Log("Game Over!");
                rubyDead(rubyDieSound, true);
            }

            if (hit.collider.gameObject.tag == "Coin")
            {
                shadowCoin++;
            }
        }
    }

    //Ruby dead event
    void rubyDead(AudioClip rubyDieSound, bool checkDead)
    {      
        audio.clip = rubyDieSound;
        audio.Play();
        rubyIsDead = checkDead;

    }
}