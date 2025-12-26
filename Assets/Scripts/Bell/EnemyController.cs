using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("ターゲット")]
    [SerializeField] GameObject Nabe;
    private UnityEngine.AI.NavMeshAgent NavMeshAgent;

    void Start()
    {
        //this.GetComponent<NavMeshAgent>().enabled = true;
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //this.transform.LookAt(Nabe.transform);//鍋の方向を向く
        NavMeshAgent.updateRotation = true;//(向き変えるやつ、NavMeshは勝手にやってくれるらしい、神？)
        NavMeshAgent.SetDestination(Nabe.transform.position);//鍋に向かってNavMesh上を移動
    }
}
