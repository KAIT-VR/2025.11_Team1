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
        mikan.transform.localScale = new Vector3(mikanSize, mikanSize, mikanSize); // 1.5î{Ç…ägëÂ

        Rigidbody rb = mikan.GetComponent<Rigidbody>();
        rb.velocity = muzzle.forward * mikanSpeed;
    }

    void Update()
    {
        float triggerValue = rightTrigger.action.ReadValue<float>();

        if (triggerValue > 0.8f && !fired)//âEÉgÉäÉKÅ[ÇÃì¸óÕÇ™0.8à»è„ÇæÇ¡ÇΩÇÁ
        {
            Fire();//î≠éÀ
            fired = true;//ëΩèdî≠éÀñhé~ÇÃbool
        }
        if (triggerValue < 0.3f)//ÉgÉäÉKÅ[Ç™0.3ñ¢ñûÇ‹Ç≈ñﬂÇ¡ÇΩÇÁçƒî≠éÀâ¬î\
        {
            fired = false;
        }
    }
}
