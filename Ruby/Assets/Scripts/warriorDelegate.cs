using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warriorDelegate : MonoBehaviour
{
    public delegate void MyDelegate();
    public static event MyDelegate enemyDelegate;
    private warriorDetectEnemy detect;
    // Start is called before the first frame update
    void Start()
    {
        detect = gameObject.GetComponent<warriorDetectEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        warriorDelegate.enemyDelegate = detect.detectionChecker;
        enemyDelegate();
    }
}
