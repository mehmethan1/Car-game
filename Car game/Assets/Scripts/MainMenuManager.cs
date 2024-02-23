using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject Game2Lock , Game3Lock;

    void Start()
    {
        if (PlayerPrefs.GetInt("IsSecondSceneUnlocked", 0) == 1)
        {
            Game2Lock.SetActive(false);
        }

        if (PlayerPrefs.GetInt("IsSecondSceneUnlocked2", 0) == 1)
        {
            Game3Lock.SetActive(false);
        }
    }
}
