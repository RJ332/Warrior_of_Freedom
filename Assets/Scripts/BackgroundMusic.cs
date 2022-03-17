using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusic : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private int firstPlayInt;
    public Slider backgroundSlider;
    public AudioSource backgroundMusic;
    private float backgroundFloat;

    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0) {
            backgroundFloat = .125f;
            backgroundSlider.value = backgroundFloat;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        } else {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            backgroundSlider.value = backgroundFloat;
        }
    }

    // Update is called once per frame
    void Update()
    {
       //backgroundMusic.volume = volumemusic; 
    }

    public void updateVolume()
    {
        backgroundMusic.volume = backgroundSlider.value;
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
    }

    void OnApplicationFocus(bool inFocus)
    {
        if(!inFocus) {
            SaveSoundSettings();
        }
    }
}
