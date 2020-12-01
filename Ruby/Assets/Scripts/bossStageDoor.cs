using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossStageDoor : MonoBehaviour
{
    public Transform[] door;
    private bool triggerDoor = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkDoor();
    }
    void checkDoor()
    {
        if (door.Length == 0)
        {
            return;
        }
        else
        {
            if (triggerDoor == true)
            {
                for (int i = 0; i < door.Length; i++)
                {
                    if (door[i].position.y < 70)
                    {
                        door[i].position += new Vector3(0, 15 * Time.deltaTime, 0);
                    }
                    else
                    {
                        door[i].gameObject.tag = "Untagged";
                    }
                }
            }
        }
    }
    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "bossStage")
        {
            triggerDoor = true;
        }
    }
}
