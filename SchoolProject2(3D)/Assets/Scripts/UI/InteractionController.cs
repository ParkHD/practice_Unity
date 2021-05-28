using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{

    public static string TargetName
    {
        get;
        private set;
    }

    [SerializeField] Transform rayPivot;
    [SerializeField] float range;
    [SerializeField] LayerMask mask;

    private void Update()
    {
        Ray ray = new Ray(rayPivot.position, rayPivot.forward);
        RaycastHit hit;
        Debug.DrawRay(rayPivot.position, rayPivot.forward * range, Color.red);
        if (Physics.Raycast(ray, out hit, range, mask))
        {
            OnContact(hit.collider.gameObject);
        }
        else
        {
            TargetName = string.Empty;
        }
    }

    void OnContact(GameObject target)
    {
        Interaction interaction = target.GetComponent<Interaction>();
        if (interaction != null)
        {
            TargetName = interaction.GetName();

            if (Input.GetKeyDown(KeyCode.F))
            {
                // �ݰڴ�.
                Item item = interaction.GetItem();
                // �κ��丮�� �ֵ�...
                Debug.Log(string.Format("Get Item : {0}[{1}]", item.name, item.count));
            }
        }
    }

}
