using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] items;

    private void Start()
    {
        Spawn();
    }
    void Spawn()
    {
        int index = Random.Range(0, 2);
        Instantiate(items[index],transform.position, Quaternion.identity, transform);
    }
}
