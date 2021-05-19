    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gemParent;
    Gem[] gemArray;
    int MAX_GEM_COUNT;
    int gemCount;

    private void Awake()
    {
        gemArray = gemParent.transform.GetComponentsInChildren<Gem>();
        MAX_GEM_COUNT = gemArray.Length;
        gemCount = 0;

        for(int i = 0;i<gemArray.Length; i++)
        {
            gemArray[i].OnGetGem += CheckGem;
        }
    }
    private void Start()
    {
        UIManager.Instance.UpdateGemCount(MAX_GEM_COUNT, gemCount);
    }
    void CheckGem()
    {
        gemCount++;
        UIManager.Instance.UpdateGemCount(MAX_GEM_COUNT, gemCount);
        if(gemCount >= MAX_GEM_COUNT)
        {
            UIManager.Instance.ShowResult();
        }
    }
}
