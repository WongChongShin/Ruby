using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class paladdinMove : MonoBehaviour
{
    public Transform[] point;
    private int finalPoint = 0;
    private NavMeshAgent agent;
    public int speed;
    private double observeTime = 0.0;
    private double observeFinishTime = 0.05;
    public Animator anim;
    public static bool noEnermy = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GetComponent<NavMeshAgent>().speed = speed;
        anim = GetComponent<Animator>();
        agent.autoBraking = false;
        anim.SetBool("isObserve", false);
    }
    void nextPoint()
    {
        if (noEnermy)
        {
            if (point.Length == 0)
            {
                return;
            }
            anim.SetBool("isObserve", false);
            anim.SetBool("isWalk", true);
            agent.destination = point[finalPoint].position;
            finalPoint = (finalPoint + 1) % point.Length;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (noEnermy)
        {
            if (agent.remainingDistance < 0.5)
            {
                observeTime += (double)Time.deltaTime;
                if (observeTime > observeFinishTime)
                {
                    observeTime = 0;
                    nextPoint();
                }

            }
        }
    }
}
