using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class cheatScript : MonoBehaviour
{
    private bool cheatOn = false;
    private bool cheatOn1 = false;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthCheat();
        if (cheatOn == true)
        {
            if (healthPoint.health < 3)
            {
                healthPoint.health = 3;
            }
        }
        bossCheat();
        if (cheatOn1 == true)
        {
            Vector3 temp = new Vector3(556.3f, 54.6f, 478f);
            enemy.transform.position = temp;
        }
    }

    void healthCheat()
    {
        if (Input.GetButtonDown("cheat health"))
        {
            if (cheatOn == false)
            {
                cheatOn = true;
            }
            else if (cheatOn == true)
            {
                cheatOn = false;
            }
        }
    }
    void bossCheat()
    {
        if (Input.GetButtonDown("cheat stand"))
        {
            if (cheatOn1 == false)
            {
                cheatOn1 = true;
            }
            else if (cheatOn1 == true)
            {
                cheatOn1 = false;
            }
        }
    }
}
