using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    private SpriteRenderer renderer;
    private Rigidbody2D rigid;
    bool isLeft;

    [SerializeField] LayerMask layerMask;
    [SerializeField] float fowardRay;
    [SerializeField] float downRay;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckWall();
        CheckGround();
        Walk();
    }
    private void Walk()
    {
        Vector2 vec = Vector2.right * (isLeft ? -1 : 1);
        rigid.AddForce(Vector2.right * vec, ForceMode2D.Impulse);
        if(rigid.velocity.x > speed)
        {
            rigid.velocity= new Vector2(speed,rigid.velocity.y);
        }
        if(rigid.velocity.x < -speed)
        {
            rigid.velocity = new Vector2(-speed, rigid.velocity.y);
        }
    }
    private void CheckWall()
    {
        Vector2 vec = Vector2.right * (isLeft ? -1 : 1);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, vec, fowardRay, layerMask);
        Debug.DrawRay(transform.position, vec * fowardRay, Color.blue);

        if (hit)
        {
            isLeft = !isLeft;
            renderer.flipX = !renderer.flipX;
        }
    }
    private void CheckGround()
    {
        Vector2 vec = Vector2.right * (isLeft ? -1 : 1) * fowardRay;
        Vector2 origin = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(origin + vec, Vector2.down, downRay, layerMask);
        Debug.DrawRay(origin + vec, Vector2.down * downRay, Color.red);
        if(!hit)
        {
            isLeft = !isLeft;
            renderer.flipX = !renderer.flipX;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            PlayerMove target = collision.gameObject.GetComponent<PlayerMove>();
            target.Damaged(transform.position);
        }
        
    }
}
