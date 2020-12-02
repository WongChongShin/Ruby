using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballCollect : MonoBehaviour
{
    public static int numGreenBall = 0;
    public static int numBlueBall = 0;
    public static int numRedBall = 0;
    public static bool textOn = false;
    private Text totalGreenBall;
    private Text totalBlueBall;
    private Text totalRedBall;
    // Start is called before the first frame update
    void Start()
    {
        totalGreenBall = GetComponent<Text>();
        totalBlueBall = GetComponent<Text>();
        totalRedBall = GetComponent<Text>();
        textOn = false;
        totalGreenBall.text = "x" + numGreenBall.ToString();
        totalBlueBall.text = "x" + numBlueBall.ToString();
        totalRedBall.text = "x" + numRedBall.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (textOn)
        {
            if (numGreenBall >= 0)
            {
                print(numGreenBall);
                totalGreenBall.text = "x" + numGreenBall.ToString();
            }
            else if (numBlueBall >= 0)
            {
                totalBlueBall.text = "x" + numBlueBall.ToString();
            }
            else if (numRedBall >= 0)
            {
                totalRedBall.text = "x" + numRedBall.ToString();
            }
        }
    }
}
