using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyDodge : MonoBehaviour
{
    public static bool isDodge = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Dodge"))
        {
            Debug.Log("is Dodge");
            isDodge = true;
        }
    }
}
