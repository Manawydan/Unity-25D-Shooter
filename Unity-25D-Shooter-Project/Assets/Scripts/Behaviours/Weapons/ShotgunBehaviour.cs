using UnityEngine;
using System.Collections;
using System;

public class ShotgunBehaviour : BaseWeapon
{
    protected override void OnShoot()
    {
        for (int i = 0; i < 4; i++)
        { 
            Instantiate(projectile.gameObject, muzzleTransform.position, muzzleTransform.rotation);
        }
    }

    protected override void OnReload()
    {
        //TODO: REALOAD LOGIC HERE
    }
}
