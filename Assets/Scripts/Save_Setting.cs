using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class Save_Setting : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    public Slider musicSlider;
    private bool isFullScreenvalue;

    private void Start()
    {
        
            musicSlider.value = PlayerPrefs.GetFloat("volume");
            audioMixer.SetFloat("volume", volumeValue);
        
       
    }

    public void SaveData()
    {
        audioMixer.SetFloat("volume", volumeValue);
        PlayerPrefs.SetFloat("volume", volumeValue);
        Screen.fullScreen = isFullScreenvalue;
        
    }

    private float volumeValue =0;
    public void SetVolume(float volume)

    {
       volumeValue = volume;    
    }

    public void SetFullScreen(bool isFullScreen)
    {
       isFullScreenvalue = isFullScreen;
    }
    

}
