using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public SpawnBricksManager spawnBrickManager;
    private HealthManager healthManager;
    public SpawnBallManager spawnBallManager;

    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text healthText;
    public TMP_Text scoreText;

    public float score;

    [SerializeField] private GameObject buttonRestart;
    [SerializeField] private GameObject launchUI;

    public bool menuActivate;

    private void Awake()
    {
        spawnBrickManager = GetComponent<SpawnBricksManager>();
        healthManager = GetComponent<HealthManager>();
        spawnBallManager = GetComponent<SpawnBallManager>();
    }

    private void Update()
    {
        if (spawnBallManager.ballServed == false)
            launchUI.SetActive(true);
        else
            launchUI.SetActive(false);
    }

    public void OnShowUI(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            buttonRestart.SetActive(buttonRestart.activeSelf == false ? true : false);
            Time.timeScale = buttonRestart.activeSelf == true ? Time.timeScale = 0 : 1;
        }
    }
    public void UpdateLevelText()
    {
        levelText.text = spawnBrickManager.currentLevelCount.ToString();

        if (spawnBrickManager.currentLevelCount >= 3)
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
        scoreText.text = score.ToString("000");
    }
}
