using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum AttackType
{
    Laser,
    Explosion
}
public class Health: MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] protected float health = 100;
    [SerializeField] protected Slider sliderHp;
    [Range(0, 50)]
    [SerializeField] private float resistanceLaser, resistanceExplosion;

    protected float[] resistances;
    protected virtual void Start()
    {
        sliderHp.maxValue = maxHealth;
        sliderHp.value = maxHealth;
        sliderHp.enabled = false;

        resistances = new float[Enum.GetValues(typeof(AttackType)).Length];
        InitializeResistances();
    }
    protected virtual void Update()
    {
        
    }
    public virtual void TakeDamage(float damage, AttackType attackType)
    {

        float actualDamage = (damage / 100) * (100 - resistances[(int)attackType]);
        health -= actualDamage;
        UpdateUI();
        if (health < 1)
        {
            Die();
        }
    }
    public virtual void AddHealth(float value)
    {
        health += value;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        UpdateUI();
    }
    protected virtual void UpdateUI()
    {
        sliderHp.value = health;
    }
    protected virtual void Die()
    {

    }
    protected virtual void InitializeResistances()
    {
        // Ініціалізація супротиву до різних видів атак
        resistances[(int)AttackType.Laser] = resistanceLaser;
        resistances[(int)AttackType.Explosion] = resistanceExplosion;
    }


}
