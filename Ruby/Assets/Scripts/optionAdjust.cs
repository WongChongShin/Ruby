using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class optionAdjust : MonoBehaviour
{
    public GameObject option;
    private bool openOption = true;
    public Slider Volume;

    public AudioSource backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Option();
        backgroundMusic.volume = Volume.value;
    }

    void Option()
    {
        if (Input.GetButtonDown("option"))
        {
            if (openOption == false)
            {
                openOption = true;
                option.SetActive(true);
            }
            else if (openOption == true)
            {
                openOption = false;
                option.SetActive(false);
            }
        }
    }
}
