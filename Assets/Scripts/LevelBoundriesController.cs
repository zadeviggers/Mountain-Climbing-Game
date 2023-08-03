using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundriesController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.theManager.player.Respawn();
        }
    }
}
