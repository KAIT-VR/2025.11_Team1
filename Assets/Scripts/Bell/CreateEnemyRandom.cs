using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.VFX;

public class CreateEnemyRandom : MonoBehaviour
{
    [Header("敵のプレハブ")]
    [SerializeField] GameObject enemy;
    [Header("出現候補地")]
    [SerializeField] Transform spawn1;
    [SerializeField] Transform spawn2;
    [SerializeField] Transform spawn3;
    
    [Header("候補地からの出現半径")]
    [SerializeField] float r = 10;

    Transform[] spawns = new Transform[3];//3箇所を配列化
    private float time;
    NavMeshHit hit;

    void Start()
    {
        spawns[0] = spawn1;
        spawns[1] = spawn2;
        spawns[2] = spawn3;
    }
    void Update()
    {
        time += Time.deltaTime;
        if(time > 1.0f)
        {
            Vector3 center = spawns[Random.Range(0, 3)].position;//3箇所の中でどれか
            Vector3 offset = new Vector3(Random.Range(-r, r), 0f, Random.Range(-r, r));//選んだ点からXZをランダムに変化
            Vector3 spawnpoint = center + offset;
            
            Spawn(spawnpoint);
            
            time = 0f;
        }
    }

    private void Spawn(Vector3 pos)
    {
        //↓NavMesh上で湧かせないと歩いてくれない；；
        if (NavMesh.SamplePosition(pos, out hit, 2.0f, NavMesh.AllAreas))//spawnpointから半径2.0以内で最も近いNavMeshを探す
        {
            Instantiate(enemy, hit.position, Quaternion.identity);//そこでクローンを生成
        }
        else
        {
            Debug.LogError("NavMesh上に生成できなかった！");
        }
        
        //Debug.Log("spawnpoint : " + spawnpoint);
        //Instantiate(enemy, spawnpoint, Quaternion.identity);

    }
}
