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
    public static string TargetName
    {
        get;
        private set;
    }
    private void Start()
    {
        controller = GetComponent<PlayerController>();
    }
    private void Update()
    {
        Ray ray = new Ray(interactionPivot.position, interactionPivot.forward);
        RaycastHit hit;
        Debug.DrawRay(interactionPivot.position, interactionPivot.forward * interactionDis, Color.red);
        if (Physics.Raycast(ray, out hit, interactionDis, layermask))
        {
            Iinteraction target = hit.collider.gameObject.GetComponent<Iinteraction>();
            if(target != null)
            {
                Debug.Log("not null");

                Debug.Log(hit.transform.name);
                TargetName = target.GetName();

                if(Input.GetKeyDown(interactionKey))
                {
                    Vector3 pos = new Vector3(transform.position.x - hit.transform.position.x, 0f, transform.position.z - hit.transform.position.z);
                    hit.collider.transform.rotation = Quaternion.FromToRotation(Vector3.forward, pos);
                    target.OnInteract();
                }
            }
            else
            {
                Debug.Log("null");
                Debug.Log(hit.transform.name);

            }
        }
        else
            TargetName = string.Empty;
    }
}
