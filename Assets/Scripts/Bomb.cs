using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public static Action OnDestroyBomb;

    [SerializeField] protected float damage;
    [SerializeField] protected float force;
    [SerializeField] protected float timeToExplosion;
    [SerializeField] protected float radiusExplosion;
    [SerializeField] protected LayerMask mask;


    [SerializeField] protected GameObject particleEffectExplosion;
    protected virtual void Start()
    {
        Invoke(nameof(Explosion), timeToExplosion);
    }
    public void UpgradeDamage(float newDamage)
    {
        damage = newDamage;
    }
    public virtual void Explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radiusExplosion, mask);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent(out Health health))
            {
                health.TakeDamage(damage, AttackType.Explosion);
            }
        }

        DestroyBomb();
    }
    private void DestroyBomb()
    {
        if(particleEffectExplosion != null)
        {
            GameObject effect = Instantiate(particleEffectExplosion, transform.position, Quaternion.identity);
            Destroy(effect, 0.9f);
        }
        OnDestroyBomb?.Invoke();
        Destroy(gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusExplosion);
    }
}
