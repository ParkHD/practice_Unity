using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxHandler : MonoBehaviour
{
    [SerializeField] AudioClip sfxAduio;

    public void OnClickButton()
    {
        SoundManager.Instance.startSfx(sfxAduio);
    }
}
