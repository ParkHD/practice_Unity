using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x < -speed)
            rigid.velocity = new Vector2(-speed, rigid.velocity.y);
        else if (rigid.velocity.x > speed)
            rigid.velocity = new Vector2(speed, rigid.velocity.y);
    }
}
