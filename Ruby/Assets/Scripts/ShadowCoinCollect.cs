using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShadowCoinCollect : MonoBehaviour
{
    public static int numOfCoin = 0;
    public static bool textOn = false;
    private Text totalCoin;

    // Start is called before the first frame update
    void Start()
    {
        totalCoin = GetComponent<Text>();
        textOn = false;
        numOfCoin = 0;
        totalCoin.text = "x" + numOfCoin.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (textOn)
        {
            if (numOfCoin >= 0)
            {
                totalCoin.text = "x"  + numOfCoin.ToString();
                
            }
        }
    }

}
