using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheatScript : MonoBehaviour
{
    private bool cheatOn = false;
    private bool checkCheat = false;
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
}
