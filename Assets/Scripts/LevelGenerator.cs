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
    public float yRandomnessMultiplier;
 
    // Prefabs
    public GripController gripPrefab;
    public SpikeController spikePrefab;
    public GameObject collectablePrefab;

    // Internal state
    float lastSegmentY = 0f;
    List<GameObject> spawnedObjects= new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // Spawn a grip on the player so they don't fall
        spawnedObjects.Add(Instantiate(gripPrefab, GameManager.theManager.player.transform.position, GameManager.theManager.player.transform.rotation).gameObject);

        if (segmentHeight <= 0)
        {
            Debug.LogError("Provide a value greater than 0 for segmentHeight!");
        } else {
            GenerateNextSegment();
        }
    }

    float RandomX()
    {
        return Random.Range(-(levelWidth / 2), levelWidth / 2);
    }
        float GetYPos(int i, int perSegment)
    {
        return lastSegmentY + (i * (segmentHeight / perSegment)) + RandomYOffset();
    }

    float RandomYOffset()
    {
        return (Random.Range(-100, 100) / 100) * yRandomnessMultiplier;
    }

    void GenerateNextSegment()
    {
        // Spawn grips
        for (int i = 0; i < numberOfGrips; i++)
        {
            spawnedObjects.Add(Instantiate(gripPrefab, new Vector3(RandomX(), GetYPos(i, numberOfGrips), 0), Quaternion.identity).gameObject);
        }
        // Spawn spikes
        for (int i = 0; i < numberOfSpikes; i++)
        {
            spawnedObjects.Add(Instantiate(spikePrefab, new Vector3(RandomX(), GetYPos(i, numberOfSpikes), 0), Quaternion.identity).gameObject);
        }
        // Spawn collectables
        for (int i = 0; i < numberOfCollectables; i++)
        {
            spawnedObjects.Add(Instantiate(collectablePrefab, new Vector3(RandomX(), GetYPos(i, numberOfCollectables), 0), Quaternion.identity).gameObject);
        }
        lastSegmentY += segmentHeight;
    }

    public void HandlePlayerMoved() {
        if (GameManager.theManager.player.transform.position.y + segmentHeight >= lastSegmentY)
        {
            GenerateNextSegment();
            RemoveOldSpawnedObjects();
        }
    }

    public void RemoveOldSpawnedObjects()
    {
        List<GameObject> toRemove = new List<GameObject>();
        foreach (GameObject obj in spawnedObjects)
        {
            if (obj.transform.position.y < lastSegmentY - (3*segmentHeight))
            {
                toRemove.Add(obj);
                Destroy(obj);
            }
        }
        // Can't remove from a list while looping over it
        toRemove.ForEach((el)=>spawnedObjects.Remove(el));
    }
}
