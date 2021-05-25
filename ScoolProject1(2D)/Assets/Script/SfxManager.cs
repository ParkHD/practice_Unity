using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    AudioSource audio;
    bool isSet; //  효과음이 재생되기전에 Destroy방지.
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(isSet && !audio.isPlaying)
        {
            Destroy(gameObject);
        }
    }
    public void PlaySfx(AudioClip clip)
    {
        isSet = true;
        audio.clip = clip;
        audio.Play();
    }                           
}
