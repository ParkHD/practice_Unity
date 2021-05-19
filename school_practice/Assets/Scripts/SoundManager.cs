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
    private void Awake()
    {
        instance = this;
        backAudio = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        backAudio.Play();
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
