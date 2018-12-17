using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource MusicPlayer;

    public void PlayMusic(string MusicName)
    {
        MusicPlayer.Stop();
        MusicPlayer.clip = Resources.Load<AudioClip>("Music/"+MusicName);
        MusicPlayer.Play();
    }
}
