using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Transform rayPivot;
    [SerializeField] float interactRange;
    [SerializeField] LayerMask targetLayer;

    public static string TargetName
    {
        get;
        private set;
    }
    // Update is called once per frame
    void Update()
    {
        Search();
    }
    void Search()
    {
        Ray ray = new Ray(rayPivot.position, rayPivot.forward);
        RaycastHit hit;

        Debug.DrawRay(rayPivot.position, rayPivot.forward * interactRange, Color.red);
        if (Physics.Raycast(ray, out hit, interactRange, targetLayer))
        {
            Iinteraction target = hit.transform.GetComponent<Iinteraction>();
            if (target != null)
            {
                TargetName = target.GetName();
                Debug.Log(TargetName);
                if(Input.GetKeyDown(KeyCode.F))
                {
                    target.OnInteract();
                }
            }
        }
        else
        {
            TargetName = null;
        }
    }
}
