﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBox : MonoBehaviour
{

    float throwForce = 600;
    Vector3 objectPos;
    float distance;

    public bool canHold = true;
    public GameObject box;
    public GameObject tempParent;
    public bool isHolding = false;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(box.transform.position, tempParent.transform.position);
        if (distance >= 100f)
        {
            isHolding = false;
        }

        if (Input.GetButtonDown("Pick Up"))
        {
            PickUp();
            //1
            if (isHolding == true)
            {
                //1
                box.GetComponent<Rigidbody>().velocity = Vector3.zero;//component
                box.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;//component
                box.transform.SetParent(tempParent.transform);


                if (Input.GetButtonDown("Throw"))
                {
                    objectPos = box.transform.position;
                    box.transform.SetParent(null);
                    box.GetComponent<Rigidbody>().useGravity = true;//component
                    box.transform.position = objectPos;

                    box.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                    isHolding = false;
                }
            }
        }       
    }

    void PickUp()
    {
       if (distance < 100f)
        {
            isHolding = true;
            box.GetComponent<Rigidbody>().useGravity = false;//component
            box.GetComponent<Rigidbody>().detectCollisions = true;//comopnent
       }
    }

    //void OnMouseUp()
    //{
    //    isHolding = false;
    //}
}