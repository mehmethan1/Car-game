using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selector : MonoBehaviour
{
    // SkinManager bileşenine referans alalım
    SkınManager skinManager;

    // Butona tıklandığında çalışacak fonksiyon
    public void OnChangeCarButtonClick(int index)
    {
        PlayerPrefs.SetInt("SkınManager", index);
        
    }

    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
