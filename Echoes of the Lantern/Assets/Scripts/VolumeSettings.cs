using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        LoadVolume();
    }

    public void SetMasterVolume()
    {
        float volume = masterSlider.value;
        myMixer.SetFloat("Master", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("masterVolume", volume);
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    void LoadVolume()
    {
        if (!PlayerPrefs.HasKey("masterVolume")) {
            PlayerPrefs.SetFloat("masterVolume", 1f);
            PlayerPrefs.SetFloat("musicVolume", 1f);
            PlayerPrefs.SetFloat("sfxVolume", 1f);
            PlayerPrefs.Save();
        }

        masterSlider.value = PlayerPrefs.GetFloat("masterVolume", 1f);
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume", 1f);
        SetAudioValues();
    }

    void SetAudioValues()
    {
        SetMasterVolume();
        SetMusicVolume();
        SetSFXVolume();
    }
}
