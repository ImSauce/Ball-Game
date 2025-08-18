using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectibleManager : MonoBehaviour
{
    public int totalCollectibles;

    public static CollectibleManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject); // avoid duplicates
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Recount collectibles each time a new scene loads
        totalCollectibles = GameObject.FindGameObjectsWithTag("PickUp").Length;
        Debug.Log($"[{scene.name}] total collectibles: {totalCollectibles}");
    }
}