using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultManager : MonoBehaviour
{
    [Header("タイマー設定")]
    public float timeLimit = 60f;
    private float currentTime;
    private bool isGameOver = false;

    [Header("UI設定")]
    public GameObject resultPanel;
    public TMP_Text resultHpText;

    [Header("他のスクリプトとの連携")]
    public NabeController nabeController;

    void Start()
    {
        currentTime = timeLimit;
        resultPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (isGameOver) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            ShowResultScreen();
        }
    }

    void ShowResultScreen()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        resultPanel.SetActive(true);

        if (nabeController != null)
        {
            resultHpText.text = "鍋の残り体力: " + nabeController.currentHp.ToString("F0");
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}