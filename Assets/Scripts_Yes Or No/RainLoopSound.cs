using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainLoopSound : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioSource audioSource;
    void Start(){
        audioSource.PlayDelayed(Random.Range(0.1f,10f));        
    }
    void Update(){
        audioSource.volume = MusicSFX.volume;
    }
}
