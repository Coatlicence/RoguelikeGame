using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDamagable : MonoBehaviour
{
    [SerializeField]
    protected int Health = 100;

    [SerializeField]
    protected int MaxHealth = 100;

    public bool Invulnerable = false;

    [SerializeField]
    protected float InvulnerableTime = 0.1f;
    private void Awake()
    {
        if(TryGetComponent<AgentQDS>(out var agentQDS))
        {
            onhalf = agentQDS.OnHalf;
        }
        OnHalfDamage += onhalf;
    }
    public void SetMaxHealth(int maxHealth)
    {
        if (maxHealth <= 0)
            throw new ArgumentException("arg health <= 0");

        MaxHealth = maxHealth;

        if (Health > MaxHealth) 
            Health = MaxHealth;
    }
    public delegate void On();
    public event On OnHalfDamage;
    public On onhalf;
    public int GetHealth()
    {
        return Health;
    }

    public void SetHealth(int health)
    {
        if (health > MaxHealth) 
            throw new ArgumentException("arg health > MaxHealth");
        if (health <= 0)
            throw new ArgumentException("arg health <= 0");

        Health = health;
    }

    public void TakeDamage(int damage)
    {
        
        if (Invulnerable) return;
        if (damage <= 0) return;

        Health -= damage;

        if (Health <= 0)
            Destroy(gameObject);

        if(Health<MaxHealth/2)
            if(OnHalfDamage != null)
                OnHalfDamage();

        Invulnerable = true;

        StartCoroutine(MakeObjectVurnerable(InvulnerableTime));

        
    }

    IEnumerator MakeObjectVurnerable(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);

        Invulnerable = false;
    }
}
