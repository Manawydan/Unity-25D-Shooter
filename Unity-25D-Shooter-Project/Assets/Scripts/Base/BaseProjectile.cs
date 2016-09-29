using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public abstract class BaseProjectile : BaseItem {

    // Projectile Atributes
    [Header("- PROJECTILE ATTRIBUTES - ")]
    public float projectileSpeed;
    public float projectileLifeTime;

    // Projectile Animation
    [Header("- ANIMATION AND PARTICLES - ")]
    public Animator projectileAnimator;
    public GameObject projectileHitParticle;

    [Header("- AUDIO EFFECTS - ")]
    public string collideAudio;

    // Auxiliar Variables
    private float currentProjectileLifeTime;

    // A classe filha deve acessar esta classe atraves do modificador protected.
    protected void Update ()
    {
        // Contar o tempo
        currentProjectileLifeTime += Time.deltaTime;
        // Checando o tempo
        if (currentProjectileLifeTime > projectileLifeTime)
        {
            Destroy(gameObject);    
        }

        transform.Translate(Vector3.right * projectileSpeed * Time.deltaTime);
    }
	
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            ApplyDamage(other.gameObject);
        }
    }

    protected void ApplyDamage(GameObject _enemy)
    {
        OnApplyDamage();
    }

    protected abstract void OnApplyDamage();

}
