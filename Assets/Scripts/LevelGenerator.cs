using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Paramaters
    public float segmentHeight;
    public int numberOfGrips;
    public int numberOfSpikes;
    public int numberOfCollectables;
    public float levelWidth;
 
    // Prefabs
    public GripController gripPrefab;
    public SpikeController spikePrefab;
    public GameObject collectablePrefab;

    // Internal state
    float lastSegmentY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (segmentHeight <= 0)
        {
            Debug.LogError("Provide a value greater than 0 for segmentHeight!");
        } else {
            GenerateNextSegment();
        }
    }

    void GenerateNextSegment()
    {
        // Spawn grips
        for (int i = 0; i < numberOfGrips; i++)
        {
            float xPos = Random.Range(-(levelWidth / 2), levelWidth / 2);
            float yPos = lastSegmentY + (i * (segmentHeight / numberOfGrips));
            Instantiate(gripPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
        }
        lastSegmentY += segmentHeight;
    }

    public void HandlePlayerMoved() {
        float currentPlayerY = GameManager.theManager.player.transform.position.y;
        if (currentPlayerY + segmentHeight >= lastSegmentY)
        {
            GenerateNextSegment();
        }
    }
}
