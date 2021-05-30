using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

    [SerializeField] GameObject Player;

    private void Awake()
    {
        instance = this;
    }
    public Vector3 PlayerPos()
    {
        return Player.transform.position;
    }
}
