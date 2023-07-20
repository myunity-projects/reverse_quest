using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAudio : MonoBehaviour
{
    [SerializeField] private bool _toggleMusic, _toggleSfx;

    public void Toggle()
    {
        if(_toggleMusic) AudioManager.Instance.ToggleMusic();
        if(_toggleSfx) AudioManager.Instance.ToggleSfx();
    }
}
