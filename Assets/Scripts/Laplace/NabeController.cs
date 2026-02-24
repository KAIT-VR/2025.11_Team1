using UnityEngine;
using UnityEngine.UI; 

public class NabeController : MonoBehaviour
{
    [Header("鍋のステータス")]
    public string nabeName = "鍋";
    public float maxHp = 100f;    
    public float currentHp;
    public float damagebyhit = 5f;
    public float cooldowntime = 1f;
    [SerializeField] Collider damageArea;

    [Header("ビジュアル設定 (任意)")]
    public Slider hpSlider;
    [SerializeField] private GameObject fill;
    public ParticleSystem smokeEffect;

    void Start()
    {
        currentHp = maxHp;
        UpdateUI();
    }

    void Update()
    {
        if (cooldowntime > 0f)
        {
            cooldowntime -= Time.deltaTime;
        }
        else
        {
            cooldowntime = 0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (cooldowntime <= 0f)
            {
                currentHp -= damagebyhit;
                
                Debug.Log("鍋のHP:" + currentHp);
                if (currentHp <= 0f)
                {
                    BreakNabe();
                }
                UpdateUI();
                cooldowntime = 1f;
            }
        }
    }

    void BreakNabe()
    {
        fill.GetComponent<Image>().enabled = false;
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
    