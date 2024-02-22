using System;
using UnityEngine;

public class Laser : MonoBehaviour
{
    protected const float speedToolDamage = 0.1f;
    [SerializeField] private float consumptionLaser = 0.01f;
    //
    private int level = 0;
    //
    [SerializeField] protected float[] damage;
    [SerializeField] protected float distanceTool;
    [SerializeField] protected Transform spawnRaycast;
    [SerializeField] protected LayerMask mask;
    //
    protected float lastTimeActiveTool;
    //
    protected PlayerInput playerInput;
    private BaggageFuel getBaggageFuel;
    //effect
    [SerializeField] private LineRenderer toolActive;
    [SerializeField] private ParticleSystem hitParticle;

    //aim
    [SerializeField] private Vector3 boxSize;
    [SerializeField] private Vector3 boxOffset;
    //
    protected bool setLaser = false;
    private void OnEnable()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        getBaggageFuel = FindObjectOfType<BaggageFuel>();
        playerInput.OnUseLaser += SwitchLaser;
    }
    private void OnDisable()
    {
        playerInput.OnUseLaser -= SwitchLaser;
    }
    private void SwitchLaser(bool value)
    {
        setLaser = value;
    }
    public bool LevelUpDamage()
    {
        if(level >= damage.Length)
        {
            return false;
        }
        else
        {
            level++;
            return true;
        }
        
    }
    protected virtual void FixedUpdate()
    {
        
        //every frame use tool switch
        if (setLaser)
        {
            UseTool();
        }
        else
        {
            UpdateLaser();
        }
    }
    protected virtual void UseTool()
    {
        if (!getBaggageFuel.RemoveFuel(consumptionLaser)) return;
        Ray ray = new Ray(spawnRaycast.position, AimEnemy());
        bool cast = Physics.Raycast(ray, out RaycastHit hit2, distanceTool, mask);
        Vector3 hitPosition = cast ? hit2.point : spawnRaycast.position + spawnRaycast.forward * distanceTool;

        //effect
        toolActive.SetPosition(0, spawnRaycast.position);
        toolActive.SetPosition(1, hitPosition);
        hitParticle.Emit(1);
        hitParticle.transform.position = hitPosition;
        if (lastTimeActiveTool < Time.time)
        {
            if (cast && hit2.collider.TryGetComponent(out Health health))
            {
                health.TakeDamage(damage[level], AttackType.Laser);
            }
            lastTimeActiveTool = Time.time + speedToolDamage;
        }
        
    }
    private Vector3 AimEnemy()
    {
        Collider[] enemy = Physics.OverlapBox(spawnRaycast.position + boxOffset, boxSize, spawnRaycast.rotation, mask);
        if (enemy.Length == 0) return spawnRaycast.forward;
        Vector3 direction = (enemy[0].gameObject.transform.position - spawnRaycast.position).normalized;
        return direction;
    }
    private void UpdateLaser()
    {
        if (!setLaser)
        {
            toolActive.SetPosition(0, Vector3.zero);
            toolActive.SetPosition(1, Vector3.zero);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(spawnRaycast.position, spawnRaycast.position + Vector3.forward * distanceTool);
        Gizmos.DrawWireCube(spawnRaycast.position + boxOffset, boxSize);
    }
}
