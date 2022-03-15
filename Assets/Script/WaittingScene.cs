using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaittingScene : MonoBehaviour
{
    [Header("Make by HiamKaito")]
    [Tooltip("Time for waitting to next scene")]
    public float waitTime = 9f;

    [Tooltip("Scene name")]
    public string name = "Home";

    void Start()
    {
        StartCoroutine(waitForNextScene());
    }

    IEnumerator waitForNextScene()
    {
        // Do intro stuff. Play animations, move gameobjects, load preloaders ect
        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(name);
    }
}
