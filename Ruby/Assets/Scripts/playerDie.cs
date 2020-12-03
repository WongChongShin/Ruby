using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDie : MonoBehaviour
{
    public AudioClip rubyDieSound;
    AudioSource audio;
    public Animator anim;
    private bool die = false;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoint.health <= 0)
        {
            if (die == false)
            {
                die = true;
                anim.SetBool("isDead", true);
                audio.clip = rubyDieSound;
                audio.Play();
            }
        }
    }
}
