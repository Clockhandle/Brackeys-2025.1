using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    [SerializeField] float minTime = 10.0f;     
    [SerializeField] float threshold = 0.3f;  
    [SerializeField] Light lightSource;      
    [SerializeField] float flashIntensity = 5f; 
    [SerializeField] float fadeDuration = 1f; 

    private float lastTime = 0;
    private Coroutine fadeCoroutine;
    private void Update()
    {
        if (Time.time - lastTime > minTime)
        {
            if (Random.value > threshold)
            {
                if (fadeCoroutine != null)
                {
                    StopCoroutine(fadeCoroutine);  
                }
                SoundManager.PlaySound(SoundType.Thundering, MusicSFX.volume);
                lightSource.intensity = flashIntensity;
                lightSource.enabled = true;           
                lastTime = Time.time;

                fadeCoroutine = StartCoroutine(FadeLightning());
            }
            else
            {
                lastTime = Time.time;
            }
        }
    }

    private IEnumerator FadeLightning()
    {
        float startIntensity = lightSource.intensity;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            lightSource.intensity = Mathf.Lerp(startIntensity, 0f, elapsedTime / fadeDuration);
            yield return null;
        }

        lightSource.enabled = false;  
    }
}
