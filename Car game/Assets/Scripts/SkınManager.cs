using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkınManager : MonoBehaviour
{
    public GameObject[] carSkins;
    int selectedCar;

    private void Start()
    {
        selectedCar = PlayerPrefs.GetInt("SelectedCar", 0);
        foreach(GameObject skin in carSkins)
        {
            skin.SetActive(false);
        }
        carSkins[selectedCar].SetActive(true);
    }

    public void ChangeCar(int index)
    {
        carSkins[selectedCar].SetActive(false);
        selectedCar = index;
        carSkins[selectedCar].SetActive(true);
        PlayerPrefs.SetInt("SkınManager", index);
    }
}
