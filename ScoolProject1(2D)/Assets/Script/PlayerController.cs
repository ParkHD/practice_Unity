using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer renderer;
    Animator ani;
    [SerializeField] float speed;
    [SerializeField] float jumpPower;
    [SerializeField] int Max_jumpCount;
    int jumpCount;

    bool isGround;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
    }
    private void Start()
    {
        jumpCount = Max_jumpCount;
    }
    private void FixedUpdate()
    {
        CheckGround();
    }
    // Update is called once per frame
    void Update()
    {
        Walk();
        Jump();
    }
    void Walk()
    {
        // 키보드에서 손을 때면 멈추도록
        if (!Input.GetButton("Horizontal"))
        {
            rigid.velocity = new Vector2(0, rigid.velocity.y);
            ani.SetBool("isRun", false);
            return;
        }
        ani.SetBool("isRun", true);
        //왼쪽 = -1, 오른쪽 = 1
        float dir = Input.GetAxisRaw("Horizontal");
        // x좌표로 이미지 반전
        renderer.flipX = (dir == -1);

        rigid.AddForce(Vector2.right * dir, ForceMode2D.Impulse);
        // 키보드를 누르고 있으면 rigid에 들어가는 힘이 중첩되서 너무 커지는것을 방지
        if(rigid.velocity.x > speed)
        {
            rigid.velocity = new Vector2(speed, rigid.velocity.y);
        }
        else if(rigid.velocity.x < -speed)
        {
            rigid.velocity = new Vector2(-speed, rigid.velocity.y);
        }
    }
    void Jump()
    {
        if(!Input.GetButtonDown("Jump"))
        {
            return;
        }
        if (jumpCount <= 0)
            return;
        // 공중에서 점프할때 그 전 velocity는 영향없도록 초기화
        rigid.velocity = Vector2.zero;
        rigid.AddForce(Vector2.up* jumpPower, ForceMode2D.Impulse);
        isGround = false;
        jumpCount--;

        SoundManager.Instance.PlaySFX("jump");
    }
    void CheckGround()
    {
        ani.SetFloat("isJump", rigid.velocity.y); 
        ani.SetBool("isGround", isGround);
        // 점프해서 올라갈때는 체크를 안한다
        if (rigid.velocity.y > 0)
        {
            return;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down,0.5f, 1 << LayerMask.NameToLayer("Ground"));
        Debug.DrawRay(transform.position, Vector2.down * 0.5f);
        if(hit)
        {
            jumpCount = Max_jumpCount;
            isGround = true;
        } 
        else
        {
            isGround = false;
        }
    }
}
