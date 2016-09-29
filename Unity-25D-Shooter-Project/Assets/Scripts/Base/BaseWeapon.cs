using UnityEngine;
using System.Collections;

public enum FIRE_MODE { SINGLE, BURST, AUTOMATIC }

public abstract class BaseWeapon : BaseItem {

    // Base Weapon Variables
    [Header("- WEAPON ATTRIBUTES - ")]
    [Range(1,100)]
    public float damageAmount;
    [Range(0.1f, 1.0f)]
    public float shootRate;
    public FIRE_MODE fireMode;
    public Transform muzzleTransform;
    public BaseProjectile projectile;

    // Base Weapon Ammunition Variables
    [Header("- AMMUNITION ATTRIBUTES - ")]
    public int ammoLoaderCapacity;
    public int ammoOutLoaderCapacity;


    // Base Weapon Audio Variables
    [Header("- AUDIO EFFECTS - ")]
    public string shootAudio;
    public string reloadAudio;

    // Base Weapon Effects Variables
    [Header("- WEAPON EFFECTS - ")]
    public GameObject projectileShell;
    public Transform shellEjectionPosition;

    // Auxiliar Variables
    private int currentAmmoInLoader;
    private int currentAmmoOutLoader;
    private bool canShoot = true;
    private int reloadAmmoAmount;

    protected void Start ()
    {
        currentAmmoInLoader = ammoLoaderCapacity;
        currentAmmoOutLoader = ammoOutLoaderCapacity;
    }

    public void Shoot ()
    {
        if (currentAmmoInLoader > 0 && canShoot)
        {
            OnShoot();
            currentAmmoInLoader--;
        }
    }

    public void Reload ()
    {
        OnReload();
        // Calcula quantos projeteis terei que colocar no carregador.
        reloadAmmoAmount = ammoLoaderCapacity - currentAmmoInLoader;
        if (currentAmmoOutLoader > reloadAmmoAmount)
        {
            currentAmmoOutLoader -= reloadAmmoAmount;
            currentAmmoInLoader += reloadAmmoAmount;      
        }
        else
        {
            currentAmmoInLoader += currentAmmoOutLoader;
            currentAmmoOutLoader = 0;  
        }


    }

    protected abstract void OnShoot ();
    protected abstract void OnReload ();
}
