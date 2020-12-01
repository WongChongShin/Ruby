using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyWin : MonoBehaviour
{

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isVictory", true);
    }

    // Update is called once per frame
    void Update()
    {
      
       
        
    }
}
