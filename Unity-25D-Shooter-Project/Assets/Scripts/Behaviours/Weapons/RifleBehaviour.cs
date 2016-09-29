using UnityEngine;
using System.Collections;
using System;

public class RifleBehaviour : BaseWeapon {

    void Start()
    {
        base.Start();
    }

    protected override void OnShoot()
    {
        Instantiate(projectile.gameObject, muzzleTransform.position, muzzleTransform.rotation);
    }

    protected override void OnReload()
    {

    }
}
