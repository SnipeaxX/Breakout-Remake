using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public BallManager ballManager;

    public int health;

    private void Awake()
    {
        ballManager = GetComponent<BallManager>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Its Lost");
            ballManager.ballServed = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
