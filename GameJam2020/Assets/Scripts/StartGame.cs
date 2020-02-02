using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void BeginSoloGame()
    {
        SceneManager.LoadScene("SoloGame");
    }

    public void BeginCoopGame()
    {

        SceneManager.LoadScene("CoopGame");

    }

    public void ExitGame()
    {

        Application.Quit();

    }

}
