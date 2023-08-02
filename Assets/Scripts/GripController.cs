using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripController : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = GameManager.theManager.player;

        if (other.CompareTag("Player"))
        {
            player.onGrip = true;
            player.transform.position = transform.position;
            player.rb.velocity = Vector3.zero;
            player.currentGrip = this;
        }
    }
}
