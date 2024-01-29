using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // Oluşturulacak nesne
    public float spawnInterval = 1f; // Oluşturma aralığı (saniye)
    public float minX = -5f; // Min oluşturma noktası
    public float maxX = 5f;  // Max oluşturma noktası

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
        // Rastgele bir x pozisyonu seç
        float randomX = Random.Range(minX, maxX);

        // Oluşturulacak nesneyi instantiate et ve rastgele konumunu belirle
        Vector3 spawnPosition = new Vector3(randomX, this.transform.position.y, this.transform.position.z);
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        // Oluşturulan nesneyi bu script'e bağlı olan GameObject altında organize et
        spawnedObject.transform.parent = transform;
    }
}
