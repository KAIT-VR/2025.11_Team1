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

    [Header("Mikan Config")]
    [SerializeField] float mikanSize = 1.5f;
    [SerializeField] float mikanSpeed = 15f;
    [SerializeField] float firerate = 0.7f;

    bool fired = false;
    float firetime = 0f;

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
        mikan.transform.localScale = new Vector3(mikanSize, mikanSize, mikanSize); // 1.5”{‚ÉŠg‘å

        Rigidbody rb = mikan.GetComponent<Rigidbody>();
        rb.velocity = muzzle.forward * mikanSpeed;
    }

    void Update()
    {
        firetime += Time.deltaTime;
        float triggerValue = rightTrigger.action.ReadValue<float>();

        if (triggerValue > 0.8f && !fired && firetime >= firerate)//‰EƒgƒŠƒK[‚Ì“ü—Í‚ª0.8ˆÈã,‚©‚ÂƒgƒŠƒK[–ß‚µŠ®—¹,‚©‚Â—˜_ƒŒ[ƒgˆÈã‚ÌŠÔŠu
        {
            Fire();//”­Ë
            fired = true;//‘½d”­Ë–h~‚Ìbool
            firetime = 0f;
        }
        if (triggerValue < 0.3f)//ƒgƒŠƒK[‚ª0.3–¢–‚Ü‚Å–ß‚Á‚½‚çÄ”­Ë‰Â”\
        {
            fired = false;
        }
    }
}
