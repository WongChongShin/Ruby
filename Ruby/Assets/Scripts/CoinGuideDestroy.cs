using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGuideDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.closeCoinGuide == true)
        {
            Destroy(gameObject);
        }
    }
}
