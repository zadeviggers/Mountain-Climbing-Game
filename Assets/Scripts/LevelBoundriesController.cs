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

    public void MoveToPlayer() {
        transform.position = new Vector3(
            transform.position.x,
            GameManager.theManager.player.transform.position.y,
            transform.position.z
        );
    }
}
