using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthPoint : MonoBehaviour
{
    public static int health = 3;
    public Texture healthFull;
    public Texture health2;
    public Texture health1;
    public Texture health0;

    private RawImage img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<RawImage>();
        img.enabled = false;
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 3)
        {
            img.texture = healthFull;
            img.enabled = true;
        }
        else if (health == 2)
        {
            img.texture = health2;
        }
        else if (health == 1)
        {
            img.texture = health1;
        }
        else if (health == 0)
        {
            img.texture = health0;
        }
    }
}
