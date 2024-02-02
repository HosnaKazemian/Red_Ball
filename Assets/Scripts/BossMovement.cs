using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float moveSpeed = 7f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 velocity = new Vector2(moveSpeed, 0f);
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            moveSpeed = -moveSpeed;
            Vector2 new_position = new Vector2(moveSpeed / 10, 0f);
            rb.MovePosition(rb.position + new_position);
        }
    }
}