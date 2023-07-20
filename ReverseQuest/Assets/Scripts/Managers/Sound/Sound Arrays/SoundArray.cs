using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public abstract class SoundArray : MonoBehaviour
{
    protected void AddAudioSource(Sound[] sounds, AudioSource audioSource)
    {
        foreach (Sound sound in sounds)
        {
            sound.audioSource = audioSource;
            sound.audioSource.clip = sound.clip;
            sound.audioSource.loop = sound.loop;
        }
    }

    protected AudioClip GetAudioClip(Sound[] sounds, AudioClipName name)
    {
        foreach (Sound sound in sounds)
        {
            if (sound.clipName == name)
            {
                return sound.clip;
            }
        }

        Debug.LogError("Sound " + name + " wasn't found!");
        return null;
    }
}
