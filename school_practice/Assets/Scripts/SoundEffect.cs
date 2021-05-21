using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    AudioSource aSource;
    bool isSet;
    private void Awake()
    {
        aSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!isSet)
            return;
        if (aSource.isPlaying == false)
            Destroy(gameObject);
    }
    public void PlaySfx(AudioClip clip)
    {
        isSet = true;
        aSource.clip = clip;
        aSource.volume = SoundManager.Instance.SfxVolume;
        aSource.Play();
    }

}
