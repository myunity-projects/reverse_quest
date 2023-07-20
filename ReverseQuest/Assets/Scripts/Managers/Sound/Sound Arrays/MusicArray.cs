using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicArray : SoundArray
{
    [SerializeField] private AudioSource _musicSource;

    public Sound[] musicArray;

    void Awake()
    {
        AddAudioSource(musicArray, _musicSource);
    }

    public void PlayMusic(AudioClipName name)
    {
        _musicSource.PlayOneShot(GetAudioClip(musicArray, name));
    }

    public void ToggleMusic()
    {
        _musicSource.mute = !_musicSource.mute;
    }
}

