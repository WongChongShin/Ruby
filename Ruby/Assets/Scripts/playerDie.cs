using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerDie : MonoBehaviour
{
    public AudioClip rubyDieSound;
    AudioSource audio;
    public Animator anim;
    public static bool die = false;
    private string levelToLoad;

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

                levelToLoad = "LoseScene";
                StartCoroutine(Wait());
                


                IEnumerator Wait()
                {
                    yield return new WaitForSeconds(3.0f);
                    SceneManager.LoadScene(levelToLoad);
                }
            }
        }

    }
}
