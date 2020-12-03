using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMusic : MonoBehaviour
{
    public Transform[] door;
    public AudioClip BackGroundMusic1;
    public AudioClip BackGroundMusic2;
    private bool startMusic=false;
    AudioSource audio1;
    AudioSource audio2;
    // Start is called before the first frame update
    void Start()
    {
        audio2 = GetComponent<AudioSource>();

    }
    void Awake()
    {
        audio1 = GetComponent<AudioSource>();
        audio1.clip = BackGroundMusic1;
        audio1.Play();
    }
    // Update is called once per frame
    void Update()
    {
        getDoorPosition();
    }
    void getDoorPosition()
    {
        for (int i = 0; i < door.Length; i++)
        {
            if (door[i].position.y > 70)
            {
                if (startMusic == false)
                {
                    startMusic = true;
                    if (audio1.isPlaying)
                    {
                        audio1.Stop();
                    }
                    if (!audio2.isPlaying)
                    {
                        StartCoroutine(wait());
                    }
                }

            }
        }
    }
    void OnTriggerEnter(Collider collisionInfo)
    {

        if (collisionInfo.gameObject.tag == "bossDoor")
        {

           
            
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        bossBackgroundMusic();



    }
    void bossBackgroundMusic()
    {
            audio2.clip = BackGroundMusic2;
            audio2.Play();
    }
}
