using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;

    [SerializeField] private float speed;
    private float minVelocity = 10;

    private Vector2 lastFrameVelocity;
    private Vector2 startDirection;

    private HealthManager healthManager;
    private UIManager uiManager;
    private SoundManager soundManager;
    private SpawnBallManager spawnBallManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        healthManager = GameObject.Find("GameManager").GetComponent<HealthManager>();
        uiManager = GameObject.Find("GameManager").GetComponent<UIManager>();
        soundManager = GameObject.Find("GameManager").GetComponent<SoundManager>();
        spawnBallManager = GameObject.Find("GameManager").GetComponent<SpawnBallManager>();
    }

    private void OnEnable()
    {
        Invoke(nameof(SetRandomTrajectory), 1);
    }
    
    private void SetRandomTrajectory()
    {
        startDirection = Vector2.zero;
        float leftOrRight = Random.Range(-1, 1);

        if (leftOrRight < 0)
        {
            startDirection.x = -1;
        }
        else
        {
            startDirection.x = 1;
        }

        startDirection.y = -1f;

        ModifyVelocity(startDirection);
    }

    private void FixedUpdate()
    {
        lastFrameVelocity = rb.velocity;
    }

    private void Bounce(Vector2 collisionNormal)
    {
        Vector2 direction = Vector3.Reflect(lastFrameVelocity, collisionNormal);

        ModifyVelocity(direction);
    }

    private void ModifyVelocity(Vector2 direction)
    {
        rb.velocity = direction.normalized * Mathf.Max(speed + (uiManager.score / 100), minVelocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bounce(collision.contacts[0].normal);

        if (collision.collider.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.collider.gameObject);

            soundManager.OnHitBrick(collision.collider.GetComponent<BrickPoint>().point);

            uiManager.score += collision.collider.GetComponent<BrickPoint>().point;
            uiManager.UpdateScore();
            uiManager.SpawnBricksManager.level.Remove(collision.collider.gameObject);
        }

        if (collision.collider.gameObject.CompareTag("Death"))
        {
            Destroy(this.gameObject);

            soundManager.OnHitDeadZone();

            healthManager.ballManager.ballServed = false;
            healthManager.TakeDamage(-1);
        }

        if (collision.collider.gameObject.CompareTag("Wall"))
        {
            soundManager.OnHitWall();
        }

        if (collision.collider.gameObject.CompareTag("Player"))
        {
            soundManager.OnHitPaddle();
        }
    }

}
