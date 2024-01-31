using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.8f;
    public float jump = 0.8f;
    public float minX;
    public float maxX;
    public float minY = -5f;
    public TextMeshProUGUI heartCountText;
    public TextMeshProUGUI scoreText;
    
    [SerializeField]
    private GameObject map;
    private int score = 0;
    private Rigidbody2D rb;
    private bool start_end = false;
    private bool isColliding = false;
    private int health;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = PlayerPrefs.GetInt("health", 5);
        for (int i = 0; i < health; i++)
        {
            heartCountText.text += "\u2665";
        }
    }

    void FixedUpdate()
    {
        scoreText.text = "score: " + score.ToString();
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(horizontal * speed, rb.velocity.y);
        rb.velocity = Vector2.Lerp(rb.velocity, movement, speed * Time.deltaTime);

        if (!start_end && 0 < vertical && Mathf.Abs(rb.velocity.y) < 0.09f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }

        if (!start_end && !isColliding && horizontal != 0)
        {
            Vector3 tmp = map.transform.position + new Vector3(-0.9f * Mathf.Sign(horizontal) * speed * Time.deltaTime, 0f, 0f);

            if (minX <= tmp.x && tmp.x <= maxX)
            {
                float middleOfScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 0)).x;
                Vector3 newPosition = new Vector3(middleOfScreen, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
                map.transform.position = tmp;
            }

            transform.Rotate(0, 0, 11f);
        }
        
        // Check if the ball falls below the specified y-coordinate
        if (transform.position.y < minY)
        {
            looseGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isColliding = true;
        }
        if (collision.gameObject.CompareTag("Start_End"))
        {
            start_end = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isColliding = false;
        }
        if (collision.gameObject.CompareTag("Start_End"))
        {
            start_end = false;
        }
    }
    
    private void looseGame()
    {
        health -= 1;
        if (health > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
            PlayerPrefs.SetInt("health", health);
        }
        else
        {
            SceneManager.LoadScene("GameOverScene");
            PlayerPrefs.DeleteAll();
        }
        
    }
    
}