using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MowaMowa : MonoBehaviour
{
    [SerializeField] Material mat;
    [SerializeField] float speed = 1.5f;        // 点滅速度
    [SerializeField] float minAlpha = 0.05f;
    [SerializeField] float maxAlpha = 0.4f;
    [SerializeField] float bias = 0.5f;       // ← これが重要（小さいほど濃い時間が長い）

    void Update()
    {
        float t = (Mathf.Sin(Time.time * speed) + 1f) * 0.5f;

        // カーブを歪ませる
        t = Mathf.Pow(t, bias);

        float alpha = Mathf.Lerp(minAlpha, maxAlpha, t);

        Color c = mat.color;
        c.a = alpha;
        mat.color = c;
    }
    /*
    [SerializeField] Material mat;
    [SerializeField] float sinpuku = 0.3f;
    [SerializeField] float syuuki = 1;
    float t;
    
    void Start()
    {
        t = 4 * sinpuku * Time.time / syuuki;
    }

    
    void Update()
    {
        Color c = mat.color;
        //c.a = Mathf.PingPong(t, 2 * sinnpuku) - sinnpuku;
        c.a = Mathf.PingPong(Time.time * 0.25f, sinpuku);
        Debug.Log(c.a);
        mat.color = c;
    }
    */
}
