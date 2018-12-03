using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackPlayer : MonoBehaviour
{
    public AudioClip[] musicTracks = new AudioClip[2];

    public AudioSource musicPlayer;

    private int index;

    private void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
    }

    private void LateUpdate()
    {
        if (!musicPlayer.isPlaying)
        {
            index++;
            playMusic(index);
        }
        else
        {
            return;
        }
    }

    void playMusic(int index)
    {
        musicPlayer.PlayOneShot(musicTracks[index]);
    }

}
