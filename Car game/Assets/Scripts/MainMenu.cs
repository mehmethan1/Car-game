using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void RestartScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void BackMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
