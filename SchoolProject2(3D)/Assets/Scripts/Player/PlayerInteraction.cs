using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] LayerMask layermask;
    [SerializeField] Transform interactionPivot;
    [SerializeField] float interactionDis;
    [SerializeField] KeyCode interactionKey;

    public static PlayerController controller;

    Iinteraction target;

    public static string TargetName
    {
        get;
        private set;
    }
    private void Start()
    {   
        controller = GetComponent<PlayerController>();
        PlayerStatus.Instance.OnRegestedEvent(interactionKey, OnInteract);
    }
    private void Update()
    {
        Ray ray = new Ray(interactionPivot.position, interactionPivot.forward);
        RaycastHit hit;
        Debug.DrawRay(interactionPivot.position, interactionPivot.forward * interactionDis, Color.red);
        if (Physics.Raycast(ray, out hit, interactionDis, layermask))
        {
            target = hit.collider.gameObject.GetComponent<Iinteraction>();
            if(target != null)
            {
                TargetName = target.GetName();
            }
            else
            {
            }
        }
        else
            TargetName = string.Empty;
    }
    void OnInteract()
    {
        if (target == null)
            return;
        if (Input.GetKeyDown(interactionKey))
        {
            target.OnInteract();
        }
    }
}
