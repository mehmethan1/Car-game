using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] gameObjects; // Game objelerinin listesi

    public GameObject policeCarPrefab; // Polis arabası prefabı

    public float timer;

    void Start()
    {
        StartCoroutine(SpawnPoliceCarRoutine());
    }

    IEnumerator SpawnPoliceCarRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer); // Her 3 saniyede bir döngüyü çalıştır

            int randomIndex = Random.Range(0, gameObjects.Length); // Game objelerinden rastgele birini seç
            GameObject selectedObject = gameObjects[randomIndex];

            Vector3 aposition = new Vector3(selectedObject.transform.position.x, -0.04f, 384);

            // Seçilen objenin pozisyonunda polis arabası spawnla
            Instantiate(policeCarPrefab, aposition, Quaternion.identity);

            Debug.Log(selectedObject);
        }
    }
}
