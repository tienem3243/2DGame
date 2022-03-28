using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MG_MT_SceneManage : MonoBehaviour
{
    public void changeScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void doExitGame()
    {
        Application.Quit();
    }
}
