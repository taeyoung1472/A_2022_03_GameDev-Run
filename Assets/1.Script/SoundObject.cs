using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundObject : PoolingBase
{
    [Header("SoundObject ฐüทร")]
    [SerializeField] AudioSource sound;
    public void Sound(AudioClip clip, float vol = 1, float pitch = 1)
    {
        sound.clip = clip;
        sound.volume = vol;
        sound.pitch = pitch;
        sound.Play();
    }
}