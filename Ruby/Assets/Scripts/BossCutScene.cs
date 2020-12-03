using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossCutScene : MonoBehaviour
{
    private string levelToLoad;
    private bool changeScene = false;
    public Transform[] door;
    private bool notReadDoor = false;

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
        if (changeScene == true)
        {
            changeScene = false;
            levelToLoad = "BossCutScene";
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(levelToLoad);
    }
    void getDoorPosition()
    {
        for (int i = 0; i < door.Length; i++)
        {
            if (door[i].position.y > 40)
            {
                changeScene = true;
                notReadDoor = true;

            }
        }
    }
}
