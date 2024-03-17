using System.Collections;
using UnityEngine;

public class Dron : EnemyMoving
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private Transform zoneExplosion;
    [SerializeField] private Vector3 scaleZone;
    private bool detonation;
    private float timer;
    [Header("CauseDamage")]
    [SerializeField] private float radiusExplosion;
    [SerializeField] private LayerMask mask;
    [SerializeField] private float damage;

    protected override void Start()
    {
        base.Start();
        zoneExplosion.gameObject.SetActive(false);
    }
    protected override void Update()
    {
        base.Update();
        Detonation();
    }
    protected void Detonation()
    {
        if (player == null) return;
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance < 3 && !detonation)
        {
            StartCoroutine(Destroy());
            detonation = true;
        }
    }
    IEnumerator Destroy()
    {
        agent.isStopped = true;
        zoneExplosion.gameObject.SetActive(true);
        while (timer < 1)
        {
            timer += Time.deltaTime;
            zoneExplosion.localScale = Vector3.Lerp(zoneExplosion.localScale, scaleZone, 1 * Time.deltaTime);
            yield return null;
        }
        CauseDamage();
        GameObject effect = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(effect, 0.9f);
        Destroy(gameObject);
    }

    private void CauseDamage()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radiusExplosion, mask);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent(out Health health))
            {
                health.TakeDamage(damage, AttackType.Explosion);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusExplosion);
    }

}
