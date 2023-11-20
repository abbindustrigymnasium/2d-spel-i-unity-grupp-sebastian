using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    // Adjust this value to set the master volume (0.0 to 1.0)
    public float masterVolume = 1.0f;

    public Slider slider;

    void Start()
    {
        // Set the initial master volume
        slider.value = AudioListener.volume;

    }

    // Set the master volume
    public void SetMasterVolume()
    {
        // Ensure volume is within the valid range (0.0 to 1.0)
        float volume = Mathf.Clamp01(slider.value);


        // Set the master volume using AudioListener
        AudioListener.volume = volume;
    }

    void update() {
        masterVolume = Mathf.Clamp01(slider.value);
    }
}
