using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnBallManager : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider2D;

    [SerializeField] private GameObject ballPrefab;
    [HideInInspector] public GameObject ball;

    public bool ballServed = false;

    private UIManager uiManager;

    private void Awake()
    {
        uiManager = GameObject.Find("GameManager").GetComponent<UIManager>();
    }

    public void Launch(InputAction.CallbackContext context)
    {
        if (context.performed && !ballServed && uiManager.menuActivate == false)
        {
            SpawnBall();
        }
    }

    public void SpawnBall()
    {
        Vector2 pos = GetRandomPointInCollider();
        ball = Instantiate(ballPrefab, pos, Quaternion.identity);
        ballServed = true;
    }

    private Vector3 GetRandomPointInCollider()
    {
        Vector2 point = new Vector2(
            Random.Range(boxCollider2D.bounds.min.x, boxCollider2D.bounds.max.x),
            Random.Range(boxCollider2D.bounds.min.y, boxCollider2D.bounds.max.y)
            );

        return point;
    }
}
