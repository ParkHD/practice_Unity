using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
    [SerializeField] new Camera camera;
    [SerializeField] float LookUpMax;
    [SerializeField] float LookUpMin;

    CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        Move();
        Look();
    }
    void Move()
    {
        if(Input.anyKey)
        {
            controller.Move(transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
            controller.Move(transform.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime);
        }
    }

    float RotationX;
    void Look()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * turnSpeed);

        float lookUp = Input.GetAxis("Mouse Y") * turnSpeed;
        RotationX += lookUp;
        RotationX = Mathf.Clamp(RotationX, LookUpMin, LookUpMax);
        camera.transform.localRotation = Quaternion.Euler(Vector3.left * RotationX);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
