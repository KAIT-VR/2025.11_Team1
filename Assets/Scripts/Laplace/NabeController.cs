using UnityEngine;
using UnityEngine.UI; 

public class NabeController : MonoBehaviour
{
    [Header("鍋のステータス")]
    public string nabeName = "鍋";
    public float maxHp = 100f;    
    public float currentHp;        

    [Header("ビジュアル設定 (任意)")]
    public Slider hpSlider;        
    public ParticleSystem smokeEffect; 

    void Start()
    {
        currentHp = maxHp;
        UpdateUI();
        Debug.Log($"{nabeName} を装備しました！ HP: {currentHp}");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Cook("激辛カレー");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Repair();
        }
    }

    public void Cook(string menuName)
    {
        if (currentHp <= 0)
        {
            Debug.Log($"<color=red>{nabeName} は割れています！これ以上料理できません！</color>");
            return;
        }

        float damage = 20f;
        currentHp -= damage;

        Debug.Log($"{menuName} を調理中... (耐久度 -{damage})");

        if (smokeEffect != null) smokeEffect.Play();

        if (currentHp <= 0)
        {
            currentHp = 0;
            BreakNabe();
        }

        UpdateUI();
    }

    public void Repair()
    {
        currentHp = maxHp;
        Debug.Log($"<color=green>{nabeName} を修理しました！ピカピカです！</color>");
        UpdateUI();
    }

    void BreakNabe()
    {
        Debug.Log("ガシャーン！鍋が壊れてしまいました...");
    }

    void UpdateUI()
    {
        if (hpSlider != null)
        {
            hpSlider.value = currentHp / maxHp;
        }
    }
}
    