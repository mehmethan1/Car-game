using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : MonoBehaviour
{
    public float speed = 5f; 

    void Update()
    {
        // z ekseninde düz hareket et
        transform.Translate(Vector3.forward * -speed * Time.deltaTime);
    }
}
