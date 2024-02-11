using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // z ekseninde düz hareket et
        transform.Translate(Vector3.forward * -speed * Time.deltaTime);
    }

    public void Explode()
    {
        speed = 0;
    }
}
