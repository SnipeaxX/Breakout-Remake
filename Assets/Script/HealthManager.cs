using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    public SpawnBallManager ballManager;

    [Range(1,3)][SerializeField] private int startingHealth;
    public int currentHealth;
    [SerializeField] private int maxHealth = 3;

    [SerializeField] private UnityEvent damageTaken;

    private void Awake()
    {
        ballManager = GetComponent<SpawnBallManager>();
        maxHealth = startingHealth;
        currentHealth = startingHealth;
        damageTaken.Invoke();
    }

    public void TakeDamage(int damage)
    {

        if (currentHealth <= 0)
        {
            Debug.Log("Its Lost");
            ballManager.ballServed = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        ModifyHealth(damage);
        damageTaken.Invoke();
    }

    private void ModifyHealth(int value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealth);
    }

}
