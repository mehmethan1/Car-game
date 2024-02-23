using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlow : MonoBehaviour
{
    public GameObject Camera;
    public Transform startPoint; // Başlangıç konumu
    public Transform endPoint;   // Bitiş konumu
    float speed = 100;     // Hareket hızı

    private bool isMoving = false;
    private float journeyLength;
    private float startTime;

    void Start()
    {
        // İki nokta arasındaki mesafeyi hesapla
        journeyLength = Vector3.Distance(startPoint.position, endPoint.position);
    }
    bool a;
    void Update()
    {
        if (isMoving)
        {
            // İki nokta arasındaki geçen süreyi hesapla
            float distCovered = (Time.time - startTime) * speed;

            // Yüzde olarak şu anki konumu bul
            float fracJourney = distCovered / journeyLength;

            // İki nokta arasında lerp kullanarak hareket ettir
            Camera.transform.position = Vector3.Lerp(startPoint.position, endPoint.position, fracJourney);

            // Bitiş noktasına ulaştıysak dur
            if (fracJourney >= 1.0f)
            {
                isMoving = false;
            }
        }
        if (a)
        {
            // İki nokta arasındaki geçen süreyi hesapla
            float distCovered = (Time.time - startTime) * speed;

            // Yüzde olarak şu anki konumu bul
            float fracJourney = distCovered / journeyLength;

            // İki nokta arasında lerp kullanarak hareket ettir
            Camera.transform.position = Vector3.Lerp(Camera.transform.position, startPoint.position, fracJourney);

            // Bitiş noktasına ulaştıysak dur
            if (fracJourney >= 1.0f)
            {
                a = false;
            }
        }

    }

    public void StartMoving()
    {
        // Butona basıldığında hareketi başlat
        startTime = Time.time;
        isMoving = true;
    }


    public void BackMoving()
    {
        // Butona basıldığında hareketi başlat
        startTime = Time.time;
        a = true;
    }
}
