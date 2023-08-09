using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    public float spinSpeed = 30f;
    void OntriigerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        //transform.Rotate(spinSpeed* Vector3.left * Time.deltaTime);
    }
}
