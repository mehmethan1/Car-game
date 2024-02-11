using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> objectList;
    public float spawnInterval = 1f; // Oluşturma aralığı (saniye)
    private float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= spawnInterval)
        {
            SpawnObject();
            elapsedTime = 0f;
        }
    }
    
    void SpawnObject()
    {
        int randomIndex = Random.Range(0, objectList.Count);

        // Oluşturulacak nesneyi instantiate et ve rastgele konumunu belirle
        Vector3 spawnPosition = new Vector3(1, this.transform.position.y, this.transform.position.z);
        GameObject spawnedObject = Instantiate(objectList[randomIndex], spawnPosition, Quaternion.identity);
    }
}