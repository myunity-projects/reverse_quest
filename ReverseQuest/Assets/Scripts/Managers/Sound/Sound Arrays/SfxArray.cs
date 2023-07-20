using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxArray : SoundArray
{
    [SerializeField] private AudioSource _sfxSource;

    public Sound[] sfxArray;

    void Awake()
    {
        AddAudioSource(sfxArray, _sfxSource);
    }

    public void PlaySfx(AudioClipName name)
    {
        _sfxSource.PlayOneShot(GetAudioClip(sfxArray ,name));
    }

    public void ToggleSfx()
    {
        _sfxSource.mute = !_sfxSource.mute;
    }
}
