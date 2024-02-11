using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 startTouchPosition;
    private Vector2 currentTouchPosition;
    private Vector2 dragDelta;

    //public GameObject OverPanel;

    public float minX = -5f;
    public float maxX = 5f;
    public float dragSpeed = 0.02f; // Hareket hızını ayarlamak için eklenen değişken


    void Update()
    {
        CheckForInput();
    }

    void CheckForInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    StartDrag(touch.position);
                    break;

                case TouchPhase.Moved:
                    ContinueDrag(touch.position);
                    break;

                case TouchPhase.Ended:
                    EndDrag();
                    break;
            }
        }
    }

    void StartDrag(Vector2 touchPosition)
    {
        isDragging = true;
        startTouchPosition = touchPosition;
        currentTouchPosition = touchPosition;
    }

    void ContinueDrag(Vector2 touchPosition)
    {
        currentTouchPosition = touchPosition;
        dragDelta = currentTouchPosition - startTouchPosition;

        float newX = Mathf.Clamp(transform.position.x + dragDelta.x * dragSpeed, minX, maxX);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        startTouchPosition = currentTouchPosition;
    }

    void EndDrag()
    {
        isDragging = false;
    }

    public void EndGame()
    {
        dragSpeed = 0;
    }
}