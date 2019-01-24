using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;

    [SerializeField] float defaultVolume = 0.7f;

    private void Start()
    {
        volumeSlider.GetComponent<Slider>().value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.GetComponent<Slider>().value = PlayerPrefsController.GetDifficulty();
    }

    private void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if(musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player has been found!");
        }
    }
}
