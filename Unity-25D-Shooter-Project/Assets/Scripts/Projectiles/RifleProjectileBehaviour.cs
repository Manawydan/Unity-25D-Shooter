using UnityEngine;
using System.Collections;
using System;

public class RifleProjectileBehaviour : BaseProjectile {

    void Update ()
    {
        base.Update();
    }

    protected override void OnApplyDamage()
    {
        throw new NotImplementedException();
    }
}
