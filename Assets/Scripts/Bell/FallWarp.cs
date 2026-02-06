using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//マップ外に落下したときに初期位置にワープさせるスクリプト

public class FallWarp : MonoBehaviour
{
    Transform spawnpoint;//プレイヤーの初期位置保存用
    Vector3 pos;
    void Start()
    {
        spawnpoint = this.gameObject.GetComponent<Transform>();//初期位置設定
        pos = spawnpoint.position;//pos経由しないと代入できないらしい
    }

    void Update()//Updateはやっぱり重いのかな、多分OnCollisionとかで実装した方がいいんだろうけど
    {
        if(this.transform.position.y < -50f)
        {
            
            this.transform.position = pos;//どっかーん
        }
    }
}
