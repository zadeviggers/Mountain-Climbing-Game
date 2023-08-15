using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    Animator animator;
    new Collider collider;
    public float spinSpeed = 30f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Disable the collider
            GetComponent<Collider>().enabled = false;

            // The animator will destory the star object once the collect animation finishes
            animator.SetTrigger("Collected");
        }
    }
}
