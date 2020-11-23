using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spartanKingDelegate : MonoBehaviour
{
    public delegate void MyDelegate();
    public static event MyDelegate enemyDelegate;
    private spartanKingDetectTarget detect;
    // Start is called before the first frame update
    void Start()
    {
        detect = gameObject.GetComponent<spartanKingDetectTarget>();
    }

    // Update is called once per frame
    void Update()
    {
        spartanKingDelegate.enemyDelegate = detect.detectionChecker;
        enemyDelegate();
    }
}
