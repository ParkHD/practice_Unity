using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [SerializeField] AudioClip backSound;
    private void Start()
    {
        SoundManager.Instance.startBgm(backSound);
    }
    public void OnStart()
    {
        SceneManager.LoadScene("GAME1");
    }
}
