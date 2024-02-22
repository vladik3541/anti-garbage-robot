using System;
using UnityEngine;
using DG.Tweening;

public class SpawnBomb : MonoBehaviour
{
    
    [SerializeField] private float consumptionBomb = 5;
    [SerializeField] private GameObject bomb;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Transform endPosition;

    [SerializeField] private float spawnRate;

    [SerializeField] private float jumpPower = 5;
    [SerializeField] private float durationJump = 3;
    private float lastSpawnTime;
    protected PlayerInput playerInput;
    private BaggageFuel getBaggageFuel;

    void OnEnable()
    {
        getBaggageFuel = FindObjectOfType<BaggageFuel>();
        playerInput = FindObjectOfType<PlayerInput>();
        playerInput.OnUseBomb += UseToolBomb;
    }
    private void OnDisable()
    {
        playerInput.OnUseBomb -= UseToolBomb;
    }
    void UseToolBomb()
    {
        if(lastSpawnTime < Time.time && getBaggageFuel.RemoveFuel(consumptionBomb))
        {
            GameObject clone = Instantiate(bomb, spawnPosition.position, Quaternion.identity);
            clone.transform.DOJump(endPosition.position, jumpPower, 1, durationJump);
            lastSpawnTime = Time.time + spawnRate;
        }

    }
}
