using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delegatePaladdin : MonoBehaviour
{
    public delegate void MyDelegate();
    public static event MyDelegate enemyDelegate;
    private paladinDetectTarget detect;
    private paladdinDie paladdin_die;
    // Start is called before the first frame update
    void Start()
    {
        detect = gameObject.GetComponent<paladinDetectTarget>();
        paladdin_die = gameObject.GetComponent<paladdinDie>();
    }

    // Update is called once per frame
    void Update()
    {
        delegatePaladdin.enemyDelegate = detect.detectionChecker;
        enemyDelegate();
    }
}
