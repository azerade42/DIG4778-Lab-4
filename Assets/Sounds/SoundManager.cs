using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip shootSound;
    public AudioClip destroySound;
    public AudioClip playerDeathSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayShootSound()
    {
        audioSource.PlayOneShot(shootSound);
    }

    public void PlayDestroySound()
    {
        audioSource.PlayOneShot(destroySound);
    }

    public void PlayPlayerDeathSound()
    {
        audioSource.PlayOneShot(playerDeathSound);
    }
}

