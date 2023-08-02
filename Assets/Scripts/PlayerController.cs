using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Parameters
    public DragPointController dragPoint;


    // Components
    Rigidbody rb;


    // Player state
    public bool onGrip = true;
    Vector2 direction;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        direction = transform.position - dragPoint.transform.position;

        Debug.DrawRay(transform.position, direction);


        if (onGrip)
        {
            rb.useGravity = false;
        }
        else
        {
            rb.useGravity = true;
        }
    }

    // When the mouse starts dragging on the player
    void OnMouseDrag()
    {
        dragPoint.HandleMouseDrag();
    }
}
