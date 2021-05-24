using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    AudioSource audio;
    bool isSet;
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
