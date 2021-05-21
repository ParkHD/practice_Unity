using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class optionManager : MonoBehaviour
{
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;

    private void OnEnable()
    {
        float bgm = SoundManager.Instance.BgmVolume;
        float sfx = SoundManager.Instance.SfxVolume;

        bgmSlider.value = bgmSlider.maxValue * bgm;
        sfxSlider.value = sfxSlider.maxValue * sfx;
    }
    private void Start()
    {

    }
    public void OnChangeBgmVolume()
    {
        SoundManager.Instance.BgmVolume = bgmSlider.value / bgmSlider.maxValue;
    }
    public void OnChangeSfxVolume()
    {
        SoundManager.Instance.SfxVolume = sfxSlider.value / sfxSlider.maxValue;
    }
}
