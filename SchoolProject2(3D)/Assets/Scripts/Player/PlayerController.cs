using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject cameraLook;
    [SerializeField] CharacterController controller;
    [SerializeField] GameObject groundChecker;
    [SerializeField] LayerMask layermask;
    [SerializeField] float groundCheckDistance;
    [SerializeField] float sensitivityX = 250f;
    [SerializeField] float sensitivityY = 250f;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float jumpPower = 3f;
    float rotationY = 0f;

    [SerializeField] float gravityScale = 1f;

    Vector3 velocity = Vector3.zero;
    bool isGrounded;
    float gravity
    {
        get
        {
            return -9.81f * gravityScale;
        }
    }
    private void Start()
    {
        UImanager.Instance.OnCursor(false);
    }
    private void OnEnable()
    {
        cameraLook.transform.localPosition = new Vector3(0f, 0.6f, 0.4f);
    }
    private void Update()
    {
        //Debug.Log(velocityY);
        Look();
        Move();
        Gravity();
        Jump();
    }
    private void FixedUpdate()
    {
        CheckGround();
    }
    void Look()
    {
        float x = Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        transform.Rotate(Vector3.up * x);

        float y = Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;
        rotationY += y;
        rotationY = Mathf.Clamp(rotationY, -90f, 75f);

        cameraLook.transform.localRotation = Quaternion.Euler(new Vector3(-rotationY, 0f, 0f));
    }
    void Move()
    {
        float z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        Vector3 move = transform.forward * z + transform.right * x;
        controller.Move(move);
    }
    void Gravity()
    {
        if (isGrounded && velocity.y < 0)
            velocity.y = 0f;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    void CheckGround()
    {
        isGrounded = Physics.CheckSphere(groundChecker.transform.position, groundCheckDistance * 0.1f, layermask);
    }
    void Jump()
    {
        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y += Mathf.Sqrt(jumpPower * -2 * gravity); ;
        } 
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundChecker.transform.position, groundCheckDistance * 0.1f);
    }
}
