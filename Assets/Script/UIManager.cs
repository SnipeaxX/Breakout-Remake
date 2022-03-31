using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public SpawnBricksManager SpawnBricksManager;
    private HealthManager healthManager;

    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text healthText;
    public TMP_Text scoreText;

    public float score;

    [SerializeField] private GameObject buttonRestart;

    public bool menuActivate;

    private void Awake()
    {
        SpawnBricksManager = GetComponent<SpawnBricksManager>();
        healthManager = GetComponent<HealthManager>();
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
        scoreText.text = score.ToString("000");
    }
}
