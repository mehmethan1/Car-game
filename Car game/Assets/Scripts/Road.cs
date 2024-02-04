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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            Debug.Log("deneme");
        }
    }
}
