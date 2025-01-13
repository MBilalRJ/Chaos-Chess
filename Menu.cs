using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public static bool isChoas = false;
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void Quit()
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }
    public void choas()
    {
        isChoas = true;
    }
    public void backToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}

