using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIGameOverText : MonoBehaviour
{

    public float letterPause = 0.2f;
    public AudioSource audioSource;
    public AudioClip sound;

    Text gameText;
    string message;

    // Use this for initialization
    void Awake()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();

        gameText = GetComponent<Text>();
        message = "connection lost...";
    }

    public void StartTyping()
    {
        StartCoroutine(Typing());
    }

    IEnumerator Typing()
    {
        foreach (char letter in message.ToCharArray())
        {
            gameText.text += letter;
            if (sound)
                audioSource.PlayOneShot(sound);
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
    }
}