using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;

    void Update()
    {
        transform.LookAt(player.transform.position);
        transform.Rotate(0, 180, 0);
    }
}
