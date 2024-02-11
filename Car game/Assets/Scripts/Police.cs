using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : MonoBehaviour
{
    public float speed = 5f;
    public GameObject object1, object2;
    public float switchInterval = 2f;
    private bool isActiveObject1 = true;
    private Coroutine switchCoroutine;

    void Start()
    {
        object1.SetActive(true);
        object2.SetActive(false);

        switchCoroutine = StartCoroutine(SwitchObjects());
    }
    IEnumerator SwitchObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(switchInterval);

            // Aktif olan objeyi deaktif et
            if (isActiveObject1)
            {
                object1.SetActive(false);
                object2.SetActive(true);
            }
            else
            {
                object1.SetActive(true);
                object2.SetActive(false);
            }

            // isActiveObject1'in durumunu değiştir
            isActiveObject1 = !isActiveObject1;
        }
    }

    // Oyun nesnesi yok edildiğinde coroutine'i durdur
    void OnDestroy()
    {
        if (switchCoroutine != null)
        {
            StopCoroutine(switchCoroutine);
        }
    }
    void Update()
    {
        // z ekseninde düz hareket et
        transform.Translate(Vector3.back * -speed * Time.deltaTime);
        this.transform.rotation = Quaternion.Euler(0, 180f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }


    public void Explode()
    {
        speed = 0;
    }
}
