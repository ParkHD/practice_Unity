using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public event Action OnGetGem;
    [SerializeField] AudioClip pickGemSound;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.name == "Player")
        {
            SoundManager.Instance.startSfx(pickGemSound);
            OnGetGem();
            gameObject.SetActive(false);
        }
    }
}
