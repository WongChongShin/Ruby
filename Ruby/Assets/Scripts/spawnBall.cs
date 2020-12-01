using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBall : MonoBehaviour
{
    public GameObject ball;
    public Transform[] door;
    public int spawnTimeSecond = 0;
    private bool startSpawn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check for the box spawn or not
        if (startSpawn == false)
        {
            //start to spawn the box
            getDoorPosition();
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(spawnTimeSecond);
        createBall();

    }
    void createBall()
    {
        Instantiate(ball, transform.position, transform.rotation);
        startSpawn = false;//the box end spawning
    }
    void getDoorPosition()
    {
        for (int i = 0; i < door.Length; i++)
        {
            if (door[i].position.y > 70)
            {
                startSpawn = true;

            }
        }
        if (startSpawn == true)
        {
            StartCoroutine(wait());
        }
    }
}
