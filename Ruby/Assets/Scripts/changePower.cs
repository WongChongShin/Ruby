using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changePower : MonoBehaviour
{
    public GameObject[] power;
    private int powerNum = 0;
    private bool startPower = false;
    private bool displayPower = false;
    public Transform[] door;
    public GameObject[] ball;
    public int changePowerTime=0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            power[i].GetComponent<ParticleSystem>().Stop();
            power[i].GetComponent<ParticleSystem>().Stop();
            power[i].GetComponent<ParticleSystem>().Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        getDoorPosition();
        if (startPower == true)
        {
            if (displayPower == false)
            {
                displayPower = true;
                StartCoroutine(wait());
            }
        }

    }

    IEnumerator wait()
    {
        power[powerNum].GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(changePowerTime);
        Instantiate(ball[powerNum], transform.position, transform.rotation);
        power[powerNum].GetComponent<ParticleSystem>().Stop();

        powerNum++;
        if (powerNum > 2)
        {
            powerNum = 0;
        }
        displayPower = false;
    }


    void getDoorPosition()
    {
        for (int i = 0; i < door.Length; i++)
        {
            if (door[i].position.y > 70)
            {
                startPower = true;

            }
        }
    }
}
