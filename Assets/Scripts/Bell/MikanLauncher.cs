using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MikanLauncher : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] InputActionReference rightTrigger;

    [Header("Mikan")]
    [SerializeField] GameObject mikanPrefab;
    [SerializeField] Transform muzzle;

    [SerializeField] float mikanSpeed = 15f;

     bool fired = false;

    private void OnEnable()
    {
        rightTrigger.action.Enable();
        //rightTrigger.action.performed += Fire;
    }

    private void OnDisable()
    {
        //rightTrigger.action.performed -= Fire;
        rightTrigger.action.Disable();
    }

    void Fire()
    {
        GameObject mikan = Instantiate(
            mikanPrefab,
            muzzle.position,
            muzzle.rotation
            );

        Rigidbody rb = mikan.GetComponent<Rigidbody>();
        rb.velocity = muzzle.forward * mikanSpeed;
    }

    void Update()
    {
        float triggerValue = rightTrigger.action.ReadValue<float>();

        if (triggerValue > 0.8f && !fired)//右トリガーの入力が0.8以上だったら
        {
            Fire();//発射
            fired = true;//多重発射防止のbool
        }
        if (triggerValue < 0.3f)//トリガーが0.3未満まで戻ったら再発射可能
        {
            fired = false;
        }
    }
}
