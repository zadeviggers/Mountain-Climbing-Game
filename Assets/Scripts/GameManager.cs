using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager theManager;
    public PlayerController player;


    // Start is called before the first frame update
    void Awake()
    {
        if (theManager == null) {
            theManager = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }


    void OnEnable()
    {
        // Add OnLevelLoaded callback
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    void OnDisable()
    {
        // Remove callback
        SceneManager.sceneLoaded -= OnLevelLoaded;
    }

    void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        player = FindFirstObjectByType<PlayerController>();
    }

}
