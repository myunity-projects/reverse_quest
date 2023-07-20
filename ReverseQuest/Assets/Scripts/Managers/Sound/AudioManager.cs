using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private SfxArray SfxArray;

    private MusicArray MusicArray;

    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SfxArray = GetComponentInChildren<SfxArray>();
        MusicArray = GetComponentInChildren<MusicArray>();
    }

    private void Start()
    {
        PlayMusic(AudioClipName.BackgroundMusic);
    }

    public void PlaySfx(AudioClipName name)
    {
        SfxArray.PlaySfx(name);
    }

    public void PlayMusic(AudioClipName name)
    {
        MusicArray.PlayMusic(name);
    }

    public void ToggleSfx()
    {
        SfxArray.ToggleSfx();
    }

    public void ToggleMusic()
    {
        MusicArray.ToggleMusic();
    }    
}
