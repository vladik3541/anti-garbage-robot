using System;
using UnityEngine;

public class DronHealth : Health
{
    public static Action OnDestroyDron;
    [SerializeField] protected GameObject explosion;
    protected Camera cam;

    protected override void Start()
    {
        base.Start();
        cam = Camera.main;
    }
    protected virtual void LateUpdate()
    {
        UpdateUI();
    }
    protected override void Die()
    {
        base.Die();
        GameObject explosionEffect = Instantiate(explosion, transform.position, Quaternion.identity);
        //Destroy(explosionEffect, 2f);
        OnDestroyDron?.Invoke();
        Destroy(gameObject);
    }
    protected override void UpdateUI()
    {
        base.UpdateUI();
        sliderHp.transform.rotation = cam.transform.rotation;
    }
}
