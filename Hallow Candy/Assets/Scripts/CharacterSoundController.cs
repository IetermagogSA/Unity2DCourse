using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundController : MonoBehaviour
{
    [Header("Character Sounds")]
    [SerializeField] AudioClip[] spawningSounds;
    [SerializeField] AudioClip[] hurtSounds;
    [SerializeField] AudioClip[] dyingSounds;
    [SerializeField] AudioClip[] attackSounds;

    // Reference to the audiosource on the character
    AudioSource audiosource;

    // Variables used to determine if the sound clip will be played - we will use a rng to determine this so that not every character plays their sound every time
    const int minSoundRNG = 1;
    const int maxSoundRNG = 5;
    const int soundRNGMagicNumber = 1;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.volume = PlayerPrefsController.GetMasterVolume();
    }

    public void PlaySpawningSound()
    {
        if(ShouldSoundPlay())
        {
            // Select which sound to play
            audiosource = GetComponent<AudioSource>();
            audiosource.PlayOneShot(spawningSounds[Random.Range(0, spawningSounds.Length)]);
        }
    }

    public void PlayHurtSound()
    {
        if (ShouldSoundPlay())
        {
            // Select which sound to play
            audiosource.PlayOneShot(hurtSounds[Random.Range(0, hurtSounds.Length)]);
        }
    }

    public void PlayDyingSound()
    {
        // Select which sound to play
        audiosource.PlayOneShot(dyingSounds[Random.Range(0, dyingSounds.Length)]);
        
    }

    public void PlayAttackSound()
    {
        // Select which sound to play
        audiosource.PlayOneShot(attackSounds[Random.Range(0, attackSounds.Length)]);
    }

    private bool ShouldSoundPlay()
    {
        if(Random.Range(minSoundRNG, maxSoundRNG) == soundRNGMagicNumber)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
