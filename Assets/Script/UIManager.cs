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
    }

    private void Update()
    {
        levelText.text = SpawnBricksManager.levelCount.ToString();
        healthText.text = healthManager.health.ToString();
        scoreText.text = score.ToString();

        if (SpawnBricksManager.levelCount >= 3)
        {
            Debug.Log("Its Win");
        }
    }
}
