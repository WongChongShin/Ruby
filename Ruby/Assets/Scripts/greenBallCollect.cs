using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class greenBallCollect : MonoBehaviour
{
    public static int numGreenBall = 0;
    public static bool textOn = false;
    private Text totalGreenBall;
    // Start is called before the first frame update
    void Start()
    {
        totalGreenBall = GetComponent<Text>();
        textOn = false;
        totalGreenBall.text = "x" + numGreenBall.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (textOn)
        {
            if (numGreenBall >= 0)
            {
                totalGreenBall.text = "x" + numGreenBall.ToString();
                textOn = false;
            }
        }
    }
}
