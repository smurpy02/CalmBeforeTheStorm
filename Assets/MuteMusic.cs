using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MuteMusic : MonoBehaviour
{
    AudioSource musicSource;
    bool muted = false;

    public InputActionReference mute;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (mute.action.WasPressedThisFrame())
        {
            muted = !muted;
            musicSource.volume = muted ? 0 : 0.2f;
        }
    }
}
