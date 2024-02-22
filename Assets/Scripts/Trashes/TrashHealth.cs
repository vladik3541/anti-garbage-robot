using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TrashHealth : Health
{
    public static Action OnCollision;
    [SerializeField] private ParticleSystem dust;
    [SerializeField] private GameObject debris;
    Rigidbody rb;
    bool isGround;
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
    }
    protected override void Die()
    {
        base.Die();
        for (int i = 0; i < Random.Range(5, 8); i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-1, 1), Random.Range(0, 3) , Random.Range(-1, 1));
            Instantiate(debris, transform.position + randomPos, Quaternion.identity);
        }
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            dust.Play();
            OnCollision?.Invoke();
            isGround = true;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isGround)
        {
            if (rb.velocity.magnitude > 0 && other.gameObject.TryGetComponent(out Health component))
            {
                component.TakeDamage(300, AttackType.Laser);// damage from fall
            }
        }
    }
    protected override void Update()
    {
        base.Update();
        UpdateUI();
    }
    protected override void UpdateUI()
    {
        base.UpdateUI();
        sliderHp.transform.rotation = Camera.main.transform.rotation;
    }


}
