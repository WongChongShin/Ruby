using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubyWinHint : MonoBehaviour
{
    private Text victoryHint;

    // Start is called before the first frame update
    void Start()
    {
        victoryHint = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(wait());

        IEnumerator wait()
        {
            yield return new WaitForSeconds(1);
            victoryHint.text = "You Win!";
        }       
    }
}
