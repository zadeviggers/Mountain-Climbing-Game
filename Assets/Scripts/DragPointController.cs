using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPointController : MonoBehaviour
{
    public PlayerController player;

    public static int distance = 10;


    void Start()
    {

    }

    void Update()
    {

    }

    // When they start dragging on the point
    void OnMouseDrag()
    {
        HandleMouseDrag();
    }

    public void HandleMouseDrag()
    {
        if (!player.onGrip)
            return;

        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = objPosition;
    }
}
