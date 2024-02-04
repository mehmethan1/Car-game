using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : MonoBehaviour
{
    public float speed = 5f; 

    void Update()
    {
        // z ekseninde düz hareket et
        transform.Translate(Vector3.left * -speed * Time.deltaTime);
        this.transform.rotation = Quaternion.Euler(90f, 0f, -90f);
    }

}
