using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseSceneCondition : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("isDead", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
