using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private bool isDragging = false;
    private Vector3 offset;
    public float minX = -0.31f; // Minimum x sınırlaması
    public float maxX = 3.47f;  // Maksimum x sınırlaması

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDragging();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopDragging();
        }

        if (isDragging)
        {
            MovePlayer();
        }
    }

    private void StartDragging()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPos();
        rb.isKinematic = false;
    }

    private void StopDragging()
    {
        isDragging = false;
        rb.isKinematic = true;
    }

    private void MovePlayer()
    {
        Vector3 targetPosition = GetMouseWorldPos() + offset;

        // Sadece x ekseni üzerinde sürükleme yapmak istiyorsanız burada sadece x'i güncelleyebilirsiniz
        float clampedX = Mathf.Clamp(targetPosition.x, minX, maxX);
        rb.MovePosition(new Vector3(clampedX, transform.position.y, transform.position.z));
    }

    private Vector3 GetMouseWorldPos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            return hit.point;
        }
        return Vector3.zero;
    }

}
