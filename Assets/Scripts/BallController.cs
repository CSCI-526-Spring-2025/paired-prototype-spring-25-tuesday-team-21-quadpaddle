using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 7f;
    private float maxSpeed = 10f;
    private Rigidbody2D rb;
    private int streakCount = 0;
    private SpriteRenderer ballSpriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballSpriteRenderer = GetComponent<SpriteRenderer>();

        float randomAngle = Random.Range(0f, 90f);
        Vector2 initialDirection = Quaternion.Euler(0, 0, randomAngle) * Vector2.up;
        rb.velocity = initialDirection * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle") || collision.gameObject.CompareTag("Obstacle"))
        {
            ChangeBallColor(collision.gameObject);

            float randomAngle = Random.Range(0f, 360f);
            Vector2 newDirection = new Vector2(
                Mathf.Cos(randomAngle * Mathf.Deg2Rad),
                Mathf.Sin(randomAngle * Mathf.Deg2Rad)
            ).normalized;

            if (Mathf.Abs(newDirection.y) < 0.3f) 
            {
                newDirection.y = newDirection.y >= 0 ? 0.3f : -0.3f;
                newDirection = newDirection.normalized;
            }

            rb.velocity = newDirection * speed;
            streakCount++;

            if (streakCount % 5 == 0 && speed < maxSpeed)
            {
                speed += 0.5f;
                rb.velocity = rb.velocity.normalized * speed;
                Debug.Log("Speed Increased: " + speed);
            }
        }
        else
        {
            GameOver();
        }
    }

    private void ChangeBallColor(GameObject paddle)
    {
        SpriteRenderer paddleRenderer = paddle.GetComponent<SpriteRenderer>();

        if (paddleRenderer != null && ballSpriteRenderer != null)
        {
            ballSpriteRenderer.color = paddleRenderer.color;
        }
    }

    private void GameOver()
    {
        rb.velocity = Vector2.zero;
        
        TimerManager timerManager = FindObjectOfType<TimerManager>();
        if (timerManager != null)
        {
            timerManager.StopTimer();
        }

        GameOverManager gameOverManager = FindObjectOfType<GameOverManager>();
        if (gameOverManager != null)
        {
            gameOverManager.ShowGameOver();
        }
    }
}