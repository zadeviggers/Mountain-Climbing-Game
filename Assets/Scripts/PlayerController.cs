using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Parameters
    public DragPointController dragPoint;
    public float speed;

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


        rb.useGravity = !onGrip;

    }

    // When the mouse starts dragging on the player
    void OnMouseDrag()
    {
        dragPoint.HandleMouseDrag();
    }

    void OnMouseUp()
    {
        HandleMouseRelease();
    }

    public void HandleMouseRelease()
    {
        if (!onGrip) return;

        // Move off grip
        onGrip = false;

        // Apply the movement
        rb.AddForce(direction * speed);

        // Reset dragpoint
        dragPoint.transform.position = Vector3.zero;
    }
}
