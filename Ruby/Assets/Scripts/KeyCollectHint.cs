using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCollectHint : MonoBehaviour
{
    private Text getkeyHint;
    //public bool getkeyTextOn = false;
    //private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        getkeyHint = GetComponent<Text>();
        //timer = 0.0f;
       // getkeyTextOn = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerCollision.youNeedKey == true)
        {
            //getkeyTextOn = true;
            getkeyHint.enabled = true;
            Debug.Log("You need a key!");
            getkeyHint.text = "You need a key!";

            StartCoroutine(wait());
        }
        else
        {
            getkeyHint.enabled = false;
        }

        IEnumerator wait()
        {
            yield return new WaitForSeconds(1);
            // getkeyTextOn = false;
            PlayerCollision.youNeedKey = false;

        }

    }
}
