using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Transform rayPivot;
    [SerializeField] float interactRange;
    [SerializeField] LayerMask targetLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
    }
    void Interact()
    {
        Ray ray = new Ray(rayPivot.position, rayPivot.forward);
        RaycastHit hit;

        Debug.DrawRay(rayPivot.position, rayPivot.forward * interactRange,Color.red);
        if (Physics.Raycast(ray, out hit, interactRange, targetLayer))
        {
            Debug.Log(hit.collider.name);
        }

    }
}
