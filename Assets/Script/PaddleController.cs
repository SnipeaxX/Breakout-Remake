using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float offsetPaddle = 1;

    private float direction;
    [SerializeField] private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -9.75f, 9.75f);
        transform.position = pos;
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = direction * speed * Time.deltaTime;
        rb.velocity = velocity;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>().x;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallController ball = collision.gameObject.GetComponent<BallController>();

        if (ball == null)
            return;

        Vector2 ballDir = (transform.position - ball.transform.position);

        if (ballDir.magnitude > offsetPaddle && Mathf.Sign(ballDir.x) == Mathf.Sign(ball.rb.velocity.x))
        {
            Vector2 ballVelocityX = ball.rb.velocity;
            ballVelocityX.x *= -1;
            ball.rb.velocity = ballVelocityX;
        }
    }
}