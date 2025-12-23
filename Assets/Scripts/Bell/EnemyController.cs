using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("常に向くターゲット")]
    [SerializeField] GameObject Nabe;

    void Update()
    {
        this.transform.LookAt(Nabe.transform);
    }
}
