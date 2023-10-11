using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIObserver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gamePanel;

    private void Start()
    {
        GameManager.gameOverEvent += ShowGameOver;
        gameOverPanel.SetActive(false);
    }

    private void ShowGameOver()
    {
        GameManager.GameOver = false;

        gameOverPanel.SetActive(true);
        gameOverPanel.GetComponent<Animator>().SetTrigger("right");
        
        gamePanel.SetActive(false);
    }
}