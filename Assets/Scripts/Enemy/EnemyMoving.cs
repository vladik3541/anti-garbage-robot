using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : MonoBehaviour
{
    protected GameObject player;
    protected NavMeshAgent agent;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (player == null) return;
        FollowToTarget();
    }
    protected virtual void FollowToTarget()
    {
        agent.SetDestination(player.transform.position);
    }
}
