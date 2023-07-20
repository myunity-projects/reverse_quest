using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public AudioClipName clipName;

    public AudioClip clip;

    public bool loop;

    [HideInInspector]
    public AudioSource audioSource;
}
