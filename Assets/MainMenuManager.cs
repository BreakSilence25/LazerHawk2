using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public AudioClip selectSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadLevel(int levelIndex)
    {
        StartCoroutine(StartLevel());

        SceneManager.LoadScene(levelIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator StartLevel()
    {
        audioSource.PlayOneShot(selectSound);
        yield return new WaitForSeconds(1f);
    }
}
