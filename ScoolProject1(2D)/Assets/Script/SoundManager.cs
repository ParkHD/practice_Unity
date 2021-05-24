using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            return instance;
        }
    }
    AudioSource audio;

    [SerializeField] AudioClip[] bgmArray;
    [SerializeField] AudioClip[] sfxArray;
    [SerializeField] GameObject soundObject;
    private string bgmName;
    private void Awake()
    {
        instance = this;
        audio = GetComponent<AudioSource>();
        bgmName = "musicbox";
    }
    private void Start()
    {
        PlayBGM(bgmName);
    }
    public void PlayBGM(string clip)
    {
        for(int i = 0;i<bgmArray.Length;i++)
        {
            if(bgmArray[i].name == clip)
            {
                audio.clip = bgmArray[i];
                audio.Play();
                break;
            }
        }
    }
    public void PlaySFX(string clip)
    {
        for(int i = 0;i< sfxArray.Length;i++)
        {
            if(sfxArray[i].name == clip)
            {
                Instantiate(soundObject).GetComponent<SfxManager>().PlaySfx(sfxArray[i]);
            }
        }
    }
}
