using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float gravityScale = 1.0f;
    [SerializeField] float jumpHight = 3f;

    [SerializeField] Transform groundChecker;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float groundDistance;

    float gravity
    {
        get
        {
            return (-9.81f * gravityScale);
        }
    }

    bool isGrounded;
    Vector3 velocity;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Gravity();
        Jump();
    }

    void Jump()
    {
        // 내가 땅에 있으면서 점프 키를 눌렀을 때.
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            velocity.y = Mathf.Sqrt(jumpHight * -2 * gravity);
    }
    void Move()
    {
        float x = Input.GetAxis("Horizontal"); // Dictionary<string, .... >;
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x) + (transform.forward * z);
        controller.Move(move * moveSpeed * Time.deltaTime);
    }
    void Gravity()
    {
        if (isGrounded && velocity.y < 0)
            velocity.y = 0f;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, groundDistance * 0.1f, groundLayer);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(groundChecker.position, groundDistance * 0.1f);
    }

}
