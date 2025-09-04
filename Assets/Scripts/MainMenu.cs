using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // public void PlayGame()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    // }

    public void level1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void level2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void level3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void level4()
    {
        SceneManager.LoadScene("Level4");
    }

    public void level5()
    {
        SceneManager.LoadScene("Level5");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
