using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blueBallCollect : MonoBehaviour
{
    
    public static int numBlueBall = 0;
    public static bool textOn = false;
    private Text totalBlueBall;
    // Start is called before the first frame update
    void Start()
    {
        totalBlueBall = GetComponent<Text>();
        textOn = false;
        totalBlueBall.text = "x" + numBlueBall.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (textOn)
        {
            
            if (numBlueBall >= 0)
            {
                totalBlueBall.text = "x" + numBlueBall.ToString();
                textOn = false;
            }

        }
    }
}