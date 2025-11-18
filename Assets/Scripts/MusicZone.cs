using System;
using UnityEngine;

public class MusicZone : MonoBehaviour
{
    public AudioClip music;

    private void OnTriggerEnter2D(Collider2D other)
    {
        AudioManager.instance.PlayMusic(music);
    }
}
