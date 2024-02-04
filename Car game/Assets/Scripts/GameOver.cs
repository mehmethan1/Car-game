using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject explosionPrefab; // Patlama efektini içeren prefab

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Invoke("StopGame", 1f);
        }

    }
    void StopGame()
    {
        // Oyun zaman ölçeğini (Time.timeScale) 0 yap
        Time.timeScale = 0f;
    }
}
