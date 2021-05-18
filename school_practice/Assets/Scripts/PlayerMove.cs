using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] float playerJump;
    private SpriteRenderer playerRenderer;
    private Rigidbody2D playerRigid;
    private Animator playerAni;

    private int MAX_JUMP_COUNT = 2;
    private int jumpCount;


    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<SpriteRenderer>();
        playerAni = GetComponent<Animator>();
        jumpCount = MAX_JUMP_COUNT;
    }
    void FixedUpdate()
    {
        CheckGround();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetButtonUp("Horizontal"))
        {
            playerRigid.velocity = new Vector2(0, playerRigid.velocity.y);
            playerAni.SetBool("isRun", false);
        }
        Jump();
    }

    void Move()
    {
        if (Input.GetButton("Horizontal") == false)
            return;

        playerAni.SetBool("isRun", true);

        float h = Input.GetAxisRaw("Horizontal");
        playerRigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (playerRigid.velocity.x < -playerSpeed)
            playerRigid.velocity = new Vector2(-playerSpeed, playerRigid.velocity.y);
        else if (playerRigid.velocity.x > playerSpeed)
            playerRigid.velocity = new Vector2(playerSpeed, playerRigid.velocity.y);

        // flipX > true:왼쪽, flase:오른쪽.
        playerRenderer.flipX = (h == -1);
    }
    void Jump()
    {
        if (jumpCount <= 0)
            return;
        if(Input.GetButtonUp("Jump"))
        {
            playerRigid.velocity = new Vector2(playerRigid.velocity.x, 0);
            playerRigid.AddForce(Vector2.up * playerJump, ForceMode2D.Impulse);
            jumpCount--;
        }
    }
    void CheckGround()
    {
        playerAni.SetFloat("isJump", playerRigid.velocity.y);

        if (playerRigid.velocity.y > 0)
        {
            playerAni.SetBool("isGround", false);
            return;
        }

        float rayDistance = 0.4f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, 1 << LayerMask.NameToLayer("Ground"));
        Debug.DrawRay(transform.position, Vector2.down * rayDistance, Color.red);
        if(hit)
        {
            jumpCount = MAX_JUMP_COUNT;
            playerAni.SetBool("isGround", true);
        }
        else
        {
            playerAni.SetBool("isGround", false);
        }
    }
}
