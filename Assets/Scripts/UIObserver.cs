using UnityEngine;

public class UIObserver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject game;

    private void Start()
    {
        GameManager.gameOverEvent += ShowGameOver;
    }

    private void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        gameOverPanel.GetComponent<Animator>().SetTrigger("right");

        Destroy(game.transform.GetChild(0).gameObject);
    }
}