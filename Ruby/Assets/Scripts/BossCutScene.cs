using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossCutScene : MonoBehaviour
{
    private string levelToLoad;
    public static bool changeScene = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (changeScene == true)
        {
            

            levelToLoad = "BossCutScene";
            StartCoroutine(Wait());

            IEnumerator Wait()
            {
                yield return new WaitForSeconds(1.0f);
                SceneManager.LoadScene(levelToLoad);
            }
            changeScene = false;
        }
    }
}
