using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] float sensitivityX;
    [SerializeField] float sensitivityY;

    private void Update()
    {
        Move();
    }
    void Move()
    {
        float x = Input.GetAxis("Mouse X");
        camera.transform.localRotation = Quaternion.Euler(0, sensitivityX * x * Time.deltaTime, 0);
    }

}
