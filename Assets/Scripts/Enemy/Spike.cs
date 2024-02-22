using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spike : EnemyMoving
{
    private const int COUNTPROJECTILE = 8;
    private const int ROTATEANGEL = 45;

    [SerializeField] private GameObject spikesParticle;
    [SerializeField] private float delaySpawnSpike;
    [SerializeField] private float distanceForAttack;

    private bool allowAttack = true;
    private Animator animator;
    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }
    protected override void FollowToTarget()
    {
        base.FollowToTarget();
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance < distanceForAttack && allowAttack)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        allowAttack = false;
        agent.isStopped = true;
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(1);// pause befor attack
        for (int i = 0; i < COUNTPROJECTILE; i++)
        {
            GameObject projectile = Instantiate(spikesParticle, transform.position, Quaternion.identity);
            projectile.transform.Rotate(0, i * ROTATEANGEL, 0);
        }
        yield return new WaitForSeconds(delaySpawnSpike);// pause befor next attack and run
        agent.isStopped = false;
        allowAttack = true;
        animator.SetBool("Attack", false);
    }
}
