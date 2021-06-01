using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] items;
    [SerializeField] Vector2 range;
    [SerializeField] int maxCount;
    [SerializeField] int minCount;
    private void Start()
    {
        Spawn();
    }
    void Spawn()
    {
        int count = Random.Range(minCount, maxCount + 1); // �����

        for(int i = 0;i<count;i++)
        {
            float posX = Random.Range(-range.x, range.x + 1);
            float posZ = Random.Range(-range.y, range.y + 1);
            int index = Random.Range(0, items.Length);// 

            Vector3 Pos = new Vector3(posX, 0f, posZ); // ������ ��ġ
            Instantiate(items[index], transform.localPosition + Pos, Quaternion.identity, transform);
        }
    }
}
