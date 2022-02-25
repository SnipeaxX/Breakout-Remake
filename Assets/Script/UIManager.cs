using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public SpawnBricksManager SpawnBricksManager;
    private HealthManager healthManager;

    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text healthText;
    public TMP_Text scoreText;

    public int score;

    private void Awake()
    {
        SpawnBricksManager = GetComponent<SpawnBricksManager>();
        healthManager = GetComponent<HealthManager>();
    }

    public void UpdateLevelText()
    {
        levelText.text = SpawnBricksManager.currentLevelCount.ToString();

        if (SpawnBricksManager.currentLevelCount >= 3)
        {
            Debug.Log("Its Win");
        }
    }

    public void UpdateHealthText()
    {
        healthText.text = healthManager.currentHealth.ToString();
    }

    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
}
