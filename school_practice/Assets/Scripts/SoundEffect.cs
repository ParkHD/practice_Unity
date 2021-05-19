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
    // Start is called before the first frame update
    void Start()
    {
        
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
        aSource.Play();
    }

}
