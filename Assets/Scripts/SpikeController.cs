using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
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
            player.Respawn();
        }
    }
}
