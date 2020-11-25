using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBox : MonoBehaviour
{
    public GameObject destroyedVersion;

    // Start is called before the first frame update
    void Start()
    {
       // countDown = delay;
    }

    // Update is called once per frame
    public void Destroy()
    {
        if (PlayerCollision.hasExploded == true)
        {
           // Instantiate(destroyedVersion, transform.position, transform.rotation);
        }
        
    }
}
