using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject Game2,Game2Lock;

    void Start()
    {
        if (PlayerPrefs.GetInt("IsSecondSceneUnlocked", 0) == 1)
        {
            Game2Lock.SetActive(false);
            Game2.SetActive(true);
        }
    }

    public void Game1()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Gam2e()
    {
        SceneManager.LoadScene("Game2");
    }
}
