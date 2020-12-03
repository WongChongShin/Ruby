using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossCutScene : MonoBehaviour
{
    private string levelToLoad;
    private bool changeDialog = false;
    public Transform[] door;
    private bool notReadDoor = false;
    public GameObject bossDialog;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        getDoorPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (notReadDoor == false)
        {
            getDoorPosition();
        }
        if (changeDialog == true)
        {
            changeDialog = false;
            bossDialog.SetActive(true);
            Vector3 temp = new Vector3(556.3f, 54.6f, 478f);
            enemy.transform.position = temp;
            StartCoroutine(Wait());
        }
    }
    void getDoorPosition()
    {
        for (int i = 0; i < door.Length; i++)
        {
            if (door[i].position.y > 40)
            {
                changeDialog = true;
                notReadDoor = true;

            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(15f);
        bossDialog.SetActive(false);
        changeDialog = false;
    }
    
}
