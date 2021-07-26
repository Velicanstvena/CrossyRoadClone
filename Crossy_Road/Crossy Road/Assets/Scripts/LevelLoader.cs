using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(++currentScene);

    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentScene);
        Debug.Log("Resetovano");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
