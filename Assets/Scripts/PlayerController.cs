using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Parameters
    public DragPointController dragPoint;
    public float speed;

    // Components
    public Rigidbody rb;


    // Player state
    public bool onGrip = false;
    public Vector2 direction;
    public GripController currentGrip = null;


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
        dragPoint.transform.localPosition = Vector3.zero;
    }
}
