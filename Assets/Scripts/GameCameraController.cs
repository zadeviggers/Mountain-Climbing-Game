using UnityEngine;
using System.Collections;

public class GameCameraController : MonoBehaviour
{
    public static float playerOffset = 0.75f;
    public static float moveDuration = 1f;

    Vector3 currentlyMovingTo;
    Vector3 startPosition;
    float moveProgress = 0;

    private void Start()
    {
        startPosition = transform.position;
        currentlyMovingTo = transform.position;
    }

    void Update()
    {
        if (currentlyMovingTo != null)
        {
            if (moveProgress < moveDuration)
            {
                moveProgress += Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, currentlyMovingTo, moveProgress / moveDuration);
            }
            // Just in case we don't make it in time
            else if (!transform.position.Equals(currentlyMovingTo))
            {
                transform.position = currentlyMovingTo;
            }
        }
    }

    public void MoveToPlayer()
    {
        MoveToPosition(
            new Vector3(
               transform.position.x,
               GameManager.theManager.player.transform.position.y + playerOffset,
               transform.position.z

            )
        );
    }

    public void MoveToPosition(Vector3 positionToMoveTo, bool shouldLerp = true)
    {
        if (shouldLerp)
        {
            // Setup for lerp 
            currentlyMovingTo = positionToMoveTo;
            startPosition = transform.position;
            moveProgress = 0;
        }
        else
        {
            transform.position = positionToMoveTo;
            currentlyMovingTo = transform.position;
            moveProgress = moveDuration;
        }
    }

}
