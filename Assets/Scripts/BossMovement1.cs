using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    private bool isColliding = false;
    public float moveSpeed = 10f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 velocity = new Vector2(-moveSpeed, 0f);
        rb.MovePosition(rb.position + velocity * Time.deltaTime);

        if(isColliding)
        {
            moveSpeed = -moveSpeed;
            isColliding = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isColliding = true;
        }
    }
}