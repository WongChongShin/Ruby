using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotate : MonoBehaviour
{
    public float rotationAmount = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Coin")
        {
            transform.Rotate(0.0f, 0.0f, rotationAmount);
        }
        else if (gameObject.tag == "Key")
        {
            transform.Rotate(0.0f, rotationAmount, 0.0f);
        }
    }
}
