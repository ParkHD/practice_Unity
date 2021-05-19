using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get { return instance; }
    }
    
    [SerializeField] GameObject result;
    [SerializeField] Text gemCountText;
    
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update

    public void ShowResult()
    {
        result.SetActive(true);
    }
    public void OnClickOk()
    {
        result.SetActive(false);
    }
    public void UpdateGemCount(int max_count, int now_count)
    {
        gemCountText.text = string.Format("{0:00}/{1:00}", now_count, max_count);    
    }
}
