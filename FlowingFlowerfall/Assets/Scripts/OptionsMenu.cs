using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using TMPro;

public class OptionsMenu : MonoBehaviour
{

    [SerializeField] Canvas canvas;
    [Header("Audio")]
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider masterVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider soundEffectSlider;
    
    [Header("Resolution")]
    [SerializeField] TMP_Dropdown resDropdown;
    [SerializeField] Toggle fullscreenToggle;

    Resolution[] resolutions;

    // Start is called before the first frame update

    void Start()
    {
        CloseOptions();
        GetResolutionOptions();
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        soundEffectSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMasterVolume() {
        audioMixer.SetFloat("MasterVolume", ConvertToDec(masterVolumeSlider.value)); // sets Master volume to the slider's value
        // value = number between 0 and 1
        PlayerPrefs.SetFloat("MasterVolume", masterVolumeSlider.value);
    }

    public void SetMusicVolume() {
        audioMixer.SetFloat("MusicVolume", ConvertToDec(musicVolumeSlider.value)); 
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);

    }

    public void SetEffectVolume() {
        audioMixer.SetFloat("SFXVolume", ConvertToDec(soundEffectSlider.value)); 
        PlayerPrefs.SetFloat("SFXVolume", soundEffectSlider.value);
    }

    float ConvertToDec(float sliderValue) {
        return Mathf.Log10(Mathf.Max(sliderValue, 0.000001f)) * 20;
    }

    void GetResolutionOptions() {
        resDropdown.ClearOptions();
        resolutions = Screen.resolutions; // static property that gives us resolutions

        for(int i = 0; i < resolutions.Length; i++) {
            
            TMP_Dropdown.OptionData newOption = new TMP_Dropdown.OptionData(resolutions[i].width.ToString() + "x" + resolutions[i].height.ToString());
            resDropdown.options.Add(newOption);
        }
    }

    public void ChooseResolution() {

        Screen.SetResolution(resolutions[resDropdown.value].width, resolutions[resDropdown.value].height, fullscreenToggle.isOn); // returns index that we selected in the list
    }


    public void OpenOptions() {
        canvas.enabled = true;

    }
    public void CloseOptions() {
        canvas.enabled = false;

    }

}
