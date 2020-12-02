using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class redBallCollect : MonoBehaviour
{
    public static int numRedBall = 0;
    public static bool textOn = false;
    private Text totalRedBall;
    // Start is called before the first frame update
    void Start()
    {
        totalRedBall = GetComponent<Text>();
        textOn = false;
        totalRedBall.text = "x" + numRedBall.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (textOn)
        {
            if (numRedBall >= 0)
            {
                totalRedBall.text = "x" + numRedBall.ToString();
            }
        }
    }
}
