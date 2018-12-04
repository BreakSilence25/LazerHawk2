using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    public GameObject pausePanel;

	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Paused();
        }

        if (pausePanel.activeSelf)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

	}

    void Paused()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeButton()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
