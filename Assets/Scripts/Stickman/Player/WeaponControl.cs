using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public static WeaponControl insWeapon;
    public bool weaponActive;
    new CircleCollider2D collider;
    private void Awake()
    {
        insWeapon = this;
    }

    private void Start()
    {
        collider = GetComponent<CircleCollider2D>();
    }
    void Update()
    {
        if (weaponActive)
            collider.enabled = true;
        else
            collider.enabled = false;
    }
}
