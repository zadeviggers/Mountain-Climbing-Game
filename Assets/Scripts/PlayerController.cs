using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Distance from the camera that things are
    public static int distance = 10;

    // Parameters
    public GameObject dragPoint;


    // Components
    Rigidbody rb;


    // Player state
    bool onGrip = true;
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

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);


        dragPoint.transform.position = objPosition;

    }
}
