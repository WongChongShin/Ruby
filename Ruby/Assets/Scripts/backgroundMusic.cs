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
    public AudioClip BackGroundMusic3;
    private Vector3 myEnemy;
    private Vector3 myPlayer;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindWithTag("enemy");
        boss = GameObject.FindWithTag("bossStage");
        audio = GetComponent<AudioSource>();
        audio.clip = BackGroundMusic2;
        audio.Play();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "bossStage")
        {
            StartCoroutine(wait());
            audio.clip = BackGroundMusic3;
            audio.Play();
        }
    }
    IEnumerator wait()
    {
        print("Here");
        yield return new WaitForSeconds(2);
        audio.Stop();
    }
}
