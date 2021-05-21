using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance
    {
        get { return instance; }
    }

    private AudioSource backAudio;
    [SerializeField] GameObject prefab;
    [SerializeField] AudioClip[] audioArray;
    [SerializeField] AudioClip[] bgmArray;

    private float bgmVolume;
    private float sfxVolume;
    public float BgmVolume
    {
        get { return bgmVolume; }
        set
        {
            bgmVolume = value;
            backAudio.volume = bgmVolume;

            PlayerPrefs.SetFloat("BGM", bgmVolume);
        }
    }
    public float SfxVolume
    {
        get { return sfxVolume; }
        set
        {
            sfxVolume = value;
            PlayerPrefs.SetFloat("SFX", sfxVolume);
        }
    }
    private void Awake()
    {
        instance = this;
        backAudio = GetComponent<AudioSource>();

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        bgmVolume = PlayerPrefs.HasKey("BGM") ? PlayerPrefs.GetFloat("BGM") : 1.0f;
        sfxVolume = PlayerPrefs.HasKey("SFX") ? PlayerPrefs.GetFloat("SFX") : 1.0f;

    }

    public void startBgm(AudioClip clip)
    {
        Debug.Log("BGM");
        Debug.Log(bgmVolume);
        for(int i = 0;i<bgmArray.Length;i++)
        {
            if(bgmArray[i] == clip)
            {
                backAudio.clip = clip;
                backAudio.volume = bgmVolume;
                backAudio.Play();
                break;
            }
        }
    }
    public void startSfx(AudioClip clip)
    {
        for(int i =0;i< audioArray.Length;i++)
        {
            if(audioArray[i].Equals(clip))
            {
                SoundEffect soundEffect = Instantiate(prefab).GetComponent<SoundEffect>();
                soundEffect.PlaySfx(audioArray[i]);
                break;
            }
        }
    }
}
