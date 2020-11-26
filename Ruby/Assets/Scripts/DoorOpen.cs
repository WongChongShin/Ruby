using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float rotationAmount = 90;
    public bool hasOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCollision.doorOpen == true && hasOpened == false)
        {
            transform.Rotate(0.0f, 0.0f, rotationAmount);
            hasOpened = true;
        }
    }
}
