using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using static UnityEngine.ParticleSystem;

public class MikanController : MonoBehaviour
{
    [Header("爆破半径")]
    [SerializeField] float explosionRadius = 5f;
    [Header("効果音")]
    [SerializeField] AudioClip SE_explosion;
    [Header("パーティクル")]
    [SerializeField] VisualEffect VFX_explosion;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(SE_explosion, transform.position);
        
        VisualEffect newVisualEffect = Instantiate(VFX_explosion);//Destroyすると効果音止まるので音用オブジェクト生成
        newVisualEffect.transform.position = this.transform.position; //同じ座標になるようににワープ
        newVisualEffect.SendEvent("OnPlay");//OffPlayは書かなくてもどうせDestroyするしいいかな
        Destroy(newVisualEffect.gameObject, 5.0f);//んで5秒後にDestroy

        Vector3 center = transform.position;
        Collider[] hits = Physics.OverlapSphere(center, explosionRadius);

        foreach (Collider hit in hits)
        {
            if (hit.transform.root.CompareTag("Enemy"))//当たったオブジェクトの親オブジェクトのタグを比較
            {
                Destroy(hit.transform.root.gameObject);
            }
        }

        Destroy(gameObject);
    }
}
