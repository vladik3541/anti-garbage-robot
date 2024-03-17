using System;
using UnityEngine;
using DG.Tweening;

public class SpawnBomb : MonoBehaviour
{
    
    [SerializeField] private float consumptionBomb = 5;
    public GameObject bomb;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private float forceShoot;

    [SerializeField] private float spawnRate;

    [SerializeField] private float jumpPower = 5;
    [SerializeField] private float durationJump = 3;
    private float lastSpawnTime;
    protected PlayerInput playerInput;
    private BaggageFuel getBaggageFuel;
    public Animator animator;
    public ParticleSystem fireEffect;

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
            GameObject clone = Instantiate(bomb, spawnPosition.position, transform.rotation);
            clone.GetComponent<Rigidbody>().AddForce(spawnPosition.forward * forceShoot, ForceMode.Force);
            lastSpawnTime = Time.time + spawnRate;
            animator.SetTrigger("ShotBomb");
            fireEffect.Play();
        }

    }
}
