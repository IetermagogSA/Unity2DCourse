using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;

    [SerializeField] float defaultVolume = 0.7f;
    [SerializeField] int defaultDifficulty = 1;

    private void Start()
    {
        LoadPlayerPrefs();
    }

    private void LoadPlayerPrefs()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        UpdateMusicVolume();

        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    private void Update()
    {
        UpdateMusicVolume();
    }

     private void UpdateMusicVolume()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player has been found!");
        }
    }

    public void ResetOptionsToDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }

    public void SaveSettings()
    {
        // Save Volume Setting
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);

        // Save Difficulty Setting
        PlayerPrefsController.SetDifficulty((int)difficultySlider.value);

        // Load the previous scene
        FindObjectOfType<LevelLoader>().LoadMainMenuNoWait();
    }

    public void ExitNoSave()
    {
        LoadPlayerPrefs();
        FindObjectOfType<LevelLoader>().LoadMainMenuNoWait();
    }
    
}
