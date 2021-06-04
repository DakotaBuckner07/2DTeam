using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SelectVolumn : MonoBehaviour
{
    public AudioMixerGroup mixer;
    public void SetLevel(float sliderValue)
    {
        mixer.audioMixer.SetFloat(mixer.name, Mathf.Log10(sliderValue) * 20);
    }
}
