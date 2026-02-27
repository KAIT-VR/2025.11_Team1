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

    [Header("効果音")]
    [SerializeField] AudioClip SE_successed;
    [SerializeField] AudioClip SE_failed;
    [SerializeField] GameObject Nabe;

    AudioSource audioSource;

    [Header("他のスクリプトとの連携")]
    public NabeController nabeController;

    void Start()
    {
        currentTime = timeLimit;
        //resultPanel.SetActive(false);
        Time.timeScale = 1f;
        audioSource = GetComponent<AudioSource>();
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

    public void ShowResultScreen()
    {
        isGameOver = true;
        //Time.timeScale = 0f;
        resultPanel.SetActive(true);
        nabeController.NabeStop();

        if (nabeController != null)
        {
            resultHpText.text = "鍋の残り体力: " + nabeController.currentHp.ToString("F0");
        }

        Vector3 Nabeposition; 
        Nabeposition.x = Nabe.transform.position.x;
        Nabeposition.y = Nabe.transform.position.y;
        Nabeposition.z = Nabe.transform.position.z;

        if(nabeController.currentHp > 0f)//防衛成功 or 失敗SE
        {
            AudioSource.PlayClipAtPoint(SE_successed, Nabeposition);
        }
        else
        {
            AudioSource.PlayClipAtPoint(SE_failed, Nabeposition);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}