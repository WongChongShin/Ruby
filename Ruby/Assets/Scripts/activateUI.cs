using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateUI : MonoBehaviour
{
    public GameObject[] powerBall;
    public Transform[] door;
    public GameObject[] BossHealth;
    private bool activeUI=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getDoorPosition();
        if (activeUI==true)
        {
            for (int i = 0; i < 6; i++)
            {
                powerBall[i].SetActive(true);
            }
            for (int i = 0; i < 2; i++)
            {
                BossHealth[i].SetActive(true);
            }
        }
    }
    void getDoorPosition()
    {
        for (int i = 0; i < door.Length; i++)
        {
            if (door[i].position.y > 70)
            {
                activeUI = true;

            }
        }
    }
}
