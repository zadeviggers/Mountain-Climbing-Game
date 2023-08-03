using UnityEngine;
using System.Collections;

public class GameCameraController : MonoBehaviour
{
    public static float playerOffset = 0.75f;

    void Start()
    {

    }

    void Update()
    {

    }

    public void MoveToPlayer()
    {
        // Move Camera 
        transform.position = new Vector3(
            transform.position.x,
            GameManager.theManager.player.transform.position.y + playerOffset,
            transform.position.z
        );
    }
}
