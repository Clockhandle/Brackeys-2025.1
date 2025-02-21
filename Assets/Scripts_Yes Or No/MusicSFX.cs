using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class MusicSFX : MonoBehaviour
{
    [SerializeField] Slider sound_slider;
    public static float volume = 0.3f;
    public void SoundVolume(){
        volume = sound_slider.value;
    }
}
