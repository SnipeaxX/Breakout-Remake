using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;

    private float direction;
    [SerializeField] private float speed;
    private float minVelocity = 10;

    private Vector2 lastFrameVelocity;
    private Vector2 force;

    private HealthManager healthManager;
    private UIManager uiManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        healthManager = GameObject.Find("GameManager").GetComponent<HealthManager>();
        uiManager = GameObject.Find("GameManager").GetComponent<UIManager>();

        
    }

    private void OnEnable()
    {
        Invoke(nameof(SetRandomTrajectory), 1);
    }
    
    private void SetRandomTrajectory()
    {
        force = Vector2.zero;
        direction = Random.Range(-1, 1);

        if (direction < 0)
        {
            force.x = -1;
        }
        else
        {
            force.x = 1;
        }

        force.y = -1f;

        rb.velocity = force * (speed + uiManager.score / 100);
    }

    private void Update()
    {
        lastFrameVelocity = rb.velocity;
        Debug.Log(rb.velocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bounce(collision.contacts[0].normal);

        if (collision.collider.gameObject.tag == "Brick")
        {
            Destroy(collision.collider.gameObject);

            uiManager.score += collision.collider.GetComponent<BrickPoint>().point;
            uiManager.UpdateScore();
            uiManager.SpawnBricksManager.level.Remove(collision.collider.gameObject);
        }

        if (collision.collider.gameObject.tag == "Death")
        {
            Destroy(this.gameObject);

            healthManager.ballManager.ballServed = false;
            healthManager.TakeDamage(-1);
        }
    }

    private void Bounce(Vector2 collisionNormal)
    {
        Vector3 direction = Vector3.Reflect(lastFrameVelocity, collisionNormal);

        rb.velocity = direction.normalized * Mathf.Max(speed + (uiManager.score / 100), minVelocity);
    }
}
