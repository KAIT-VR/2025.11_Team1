using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class MikanController : MonoBehaviour
{
    [Header("爆破半径")]
    [SerializeField] float explosionRadius = 5f;
    [Header("効果音")]
    [SerializeField] AudioClip SE_explosion;
    [Header("パーティクル")]
    [SerializeField] ParticleSystem PT_explosion;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(SE_explosion, transform.position);
        
        ParticleSystem newParticle = Instantiate(PT_explosion);
        newParticle.transform.position = this.transform.position;
        newParticle.Play();
        Destroy(newParticle.gameObject, 5.0f);

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
