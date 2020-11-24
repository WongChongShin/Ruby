using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMusic : MonoBehaviour
{
    public Transform player;
    GameObject enemy;
    GameObject boss;
    public AudioClip BackGroundMusic1;
    public AudioClip BackGroundMusic2;
    private Vector3 myEnemy;
    private Vector3 myPlayer;
    private bool audioOne = true;
    AudioSource audio1;
    AudioSource audio2;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindWithTag("enemy");
        boss = GameObject.FindWithTag("bossStage");

        

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
    }
    void OnTriggerEnter(Collider collisionInfo)
    {

        if (collisionInfo.gameObject.tag == "bossDoor")
        {
            if (audio1.isPlaying)
            {
                audio1.Stop();
            }
            StartCoroutine(wait());
            
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        bossBackgroundMusic();



    }
    void bossBackgroundMusic()
    {
        audio2 = GetComponent<AudioSource>();
        audio2.clip = BackGroundMusic2;
        audio2.Play();
    }
}
