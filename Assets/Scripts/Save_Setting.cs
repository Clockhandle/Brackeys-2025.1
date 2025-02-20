using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class Save_Setting : MonoBehaviour
{
    public Slider music_slider;
    public Slider soundeffect_slider;
    public Slider brightness_slider;
    public Toggle isFullScreenToggle;

    AudioMixer audioMixer;





    private void Start()
    {
        
    }

    private void Update()
    {

        PlayerPrefs.SetFloat("SoundEffect", soundeffect_slider.value);
        PlayerPrefs.SetFloat("Music", music_slider.value);
        PlayerPrefs.SetFloat("Brightness", brightness_slider.value);
        PlayerPrefs.SetFloat("isFullScreen", isFullScreenToggle.isOn ? 1 : 0);

    }

    public void SaveSetting(float Soundeffecct, float music, float brightness,bool isFullscreen)
    {
        music_slider.value =music;
        soundeffect_slider.value =Soundeffecct;
        brightness_slider.value =brightness;    
        isFullScreenToggle.isOn  = isFullscreen;

    }

    public void LoadSetting(float Soundeffecct, float music, float brightness, bool isFullscreen)
    {
       


    }
    private void SetSoundEffect(float volume)
    {
        
    }
    private void SetMusic(float volume)
    {
        
    }
    private void Setbrightness(float volume)
    {

    }



}
