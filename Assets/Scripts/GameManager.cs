using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject winPanel;
    public GameObject gameOverPanel;

    public GameObject fireworks;
    public Text countText;

    private AudioManager audioManager;
    private CollectibleManager collectibleManager;

    private int count;
    private bool isGameOver = false;  // <-- important flag

    private void Awake()
    {
        if (instance == null) instance = this;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        count = 0;
        SetCountText();
    }

    public void AddCollectible()
    {
        if (isGameOver) return;  // ignore if already ended
        count++;
        SetCountText();
        audioManager.PlaySFX(audioManager.collect);
    }

    private void SetCountText()
    {
        if (collectibleManager == null)
            collectibleManager = FindFirstObjectByType<CollectibleManager>();

        countText.text = count + "/" + collectibleManager.totalCollectibles;

        if (count >= collectibleManager.totalCollectibles)
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        if (isGameOver) return;
        isGameOver = true;

        audioManager.PlaySFX(audioManager.win);
        winPanel.SetActive(true);
        fireworks.SetActive(true);
        // you can add animation triggers here
    }

    public void LoseGame()
    {
        if (isGameOver) return;
        isGameOver = true;

        gameOverPanel.SetActive(true);
        Invoke("Restart", 2f);
        audioManager.PlaySFX(audioManager.lose);
        // same: trigger animations here
    }

    // restart for both win or lose
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnPlayerTrigger(Collider other)
    {
        if (isGameOver) return; // don’t allow pickups after win/lose

        if (other.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            AddCollectible();
        }
    }

    public void OnPlayerCollision(Collision collision)
    {
        if (isGameOver) return;

        if (collision.gameObject.CompareTag("Wall"))
        {
            audioManager.collideSFX(audioManager.collide);
        }
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
