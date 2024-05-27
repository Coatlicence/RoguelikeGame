using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDamagable : MonoBehaviour
{
    [SerializeField]
    protected int Health = 100;
    List<SusceptibilityPair> DamageSusceptibillity = new();
    [Serializable]

    public struct SusceptibilityPair
    {
        public DamageType damageType;
        public enum DamageType
        {
            Physical,
            Fire,
            Poison
        }
        [SerializeField]
        [Range(0f, 1f)]
        public float Susceptibillity;
    }

    [SerializeField]
    protected int MaxHealth = 100;

    public bool Invulnerable = false;


    [SerializeField]
    protected float InvulnerableTime = 0.1f;
    private void Start()
    {
        var fire = new SusceptibilityPair();
        fire.damageType = SusceptibilityPair.DamageType.Fire;
        //fire.Susceptibillity = UnityEngine.Random.value;
        fire.Susceptibillity = 0.1f;
        DamageSusceptibillity.Add(fire);

        var poison = new SusceptibilityPair();
        poison.damageType = SusceptibilityPair.DamageType.Poison;
        poison.Susceptibillity = UnityEngine.Random.value;
        DamageSusceptibillity.Add(poison);

        var physics = new SusceptibilityPair();
        physics.damageType = SusceptibilityPair.DamageType.Physical;
        physics.Susceptibillity = UnityEngine.Random.value;
        DamageSusceptibillity.Add(physics);
        //if(TryGetComponent<AgentQDS>(out var agentQDS))
        //{
        //    onhalf = agentQDS.OnHalf;
        //}
        //OnHalfDamage += onhalf;

        if (Invulnerable)
            StartCoroutine(MakeObjectVurnerable(InvulnerableTime));
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

    public void TakeDamage(uint damage)
    {
        if (Invulnerable) return;

        Health -= (int)damage;

        if (Health <= 0)
        {
            onDie();
            Destroy(gameObject);
            return;
        }

        //if(Health<MaxHealth/2)
        //    if(OnHalfDamage != null)
        //        OnHalfDamage();

        Invulnerable = true;

        StartCoroutine(MakeObjectVurnerable(InvulnerableTime));        
    }
    public void TakeDamage(uint damage, SusceptibilityPair.DamageType type)

    {
        var res = DamageSusceptibillity.Find(r => r.damageType == type);

        //if (res)
        //{
        //    Debug.LogError("No DamageType");
        //}

        if (res.Susceptibillity == 0) return;

        damage -=Convert.ToUInt32( Convert.ToDouble( damage) * res.Susceptibillity);
        TakeDamage(damage);
    }

    IEnumerator MakeObjectVurnerable(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);

        Invulnerable = false;
    }

    public delegate void OnDie();
    public OnDie onDie;
}
