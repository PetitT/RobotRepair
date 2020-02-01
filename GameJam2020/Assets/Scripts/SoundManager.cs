using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource audioSrc;

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }

    public virtual void PlaySound(AudioClip clip)
    {
        audioSrc.PlayOneShot(clip);
    }
}
