using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    [SerializeField] GameObject hpslider;
    private Slider hpslider_value;
    [SerializeField] GameObject player;
    [SerializeField] RectTransform fillarea;
    [SerializeField] TextMeshProUGUI HPText;


    // Start is called before the first frame update
    void Start()
    {
        hpslider_value = hpslider.GetComponent<Slider>();

        //HP初期値設定
        hpslider_value.value = 100;

    }

    private void Update()
    {
        this.transform.LookAt(player.transform);
    }

    public void HPbarkoushin(int HP, int MAXHP)//HPManagerから呼び出される
    {
        if(HP <= 3)
        {
            fillarea.offsetMin = new Vector2(1, 0);//HPが低いときは動く部分をちょい右にズラしていい感じにする
        }
        else
        {
            fillarea.offsetMin = new Vector2(0, 0);//4以上だったら戻す
        }
        hpslider_value.value = HP;//HPバーの位置をHPと同じにする
        //HPText.text = HP + "  /  " + MAXHP;//テキスト更新
    }
    


    /*
    void Update()//デバック用
    {
        if (hpslider_value.value <= 3)
        {
            fillarea.offsetMin = new Vector2(1, 0);
        }
        else
        {
            fillarea.offsetMin = new Vector2(0, 0);
        }
        //hpslider_value.value = HP;
    }
    */
}
