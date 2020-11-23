using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class warriorMove : MonoBehaviour
{
    public Transform[] point;
    private int finalPoint = 0;
    private NavMeshAgent agent;
    public int speed;
    public Animator anim;
    private int number = 0;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GetComponent<NavMeshAgent>().speed = speed;
        anim = GetComponent<Animator>();
        agent.autoBraking = false;
        nextPoint();
    }
    void nextPoint()
    {
        if (point.Length == 0)
        {
            return;
        }
        agent.isStopped = false;
        agent.destination = point[finalPoint].position;
        finalPoint = (finalPoint + 1) % point.Length;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(5);
        nextPoint();
    }
    public void movement()
    {
        if (agent.remainingDistance < 20)
        {
            agent.isStopped = true;
            if (agent.remainingDistance < 5)
            {
                anim.SetBool("isVictory", true);
                if (number < 1)
                {
                    StartCoroutine(wait());
                }
                number++;
            }

        }
        else
        {
            anim.SetBool("isVictory", false);
            agent.isStopped = false;
            number = 0;
        }
    }
}
