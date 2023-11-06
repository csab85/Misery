using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public Transform pauseMenu;

    void Update()
    {
        // Verifica se a cena "MainMenu" não está carregada e se a tecla Escape foi pressionada
        if (!SceneManager.GetSceneByName("MainMenu").isLoaded && Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.gameObject.activeSelf)
            {
                pauseMenu.gameObject.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                pauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        AudioManager.instance.PlayMusic("Theme");
    }
}