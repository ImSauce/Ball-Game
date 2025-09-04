using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public Text winText;
    public Text countText;
    AudioManager audioManager;
    public GameObject LevelComplete;
    CollectibleManager collectibleManager;
    private int count;
    public void CompleteLevel()
    {
        LevelComplete.SetActive(true);
    }
    
    void Start()
    {
        count = 0;
        SetCountText();
        
    }

    public void SetCountText()
    {
        if (collectibleManager == null)
        {
            collectibleManager = FindFirstObjectByType<CollectibleManager>();
        }

        countText.text = count.ToString() + "/" + collectibleManager.totalCollectibles;
        if (count >= collectibleManager.totalCollectibles)
        {
            audioManager.PlaySFX(audioManager.win);
            CompleteLevel();
            
        }
    }


    // public void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.CompareTag("PickUp"))
    //     {
    //         other.gameObject.SetActive(false);
    //         count += 1;
    //         SetCountText();
    //         audioManager.PlaySFX(audioManager.collect);
    //     }

    // }

    // public void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Wall"))
    //     {
    //         audioManager.collideSFX(audioManager.collide);
    //     }
    // }


    public void OnPlayerTrigger(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            audioManager.PlaySFX(audioManager.collect);
        }
    }

    public void OnPlayerCollision(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            audioManager.collideSFX(audioManager.collide);
        }
    }





    //---------------- AUDIO -----------------

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
}
