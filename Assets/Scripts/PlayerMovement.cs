using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jump = 5f;
    public float minCameraX;
    public float maxCameraX;
    private Rigidbody2D rb;
    private Camera mainCamera;
    private float halfScreenWidth;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        halfScreenWidth = Screen.width / 2f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(horizontal, 0f);
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);

        if (0 < vertical && Mathf.Abs(rb.velocity.y) < 0.09f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }

        if (mainCamera.ScreenToWorldPoint(new Vector3(halfScreenWidth, 0, 0)).x < transform.position.x || horizontal < 0f)
        {
            if (minCameraX < transform.position.x && transform.position.x < maxCameraX)
            {
                mainCamera.transform.position = new Vector3(transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
            }
        }
    }
}