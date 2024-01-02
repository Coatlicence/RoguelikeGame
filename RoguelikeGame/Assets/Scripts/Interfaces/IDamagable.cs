using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDamagable : MonoBehaviour
{
    [SerializeField]
    protected int Health = 100;

    [SerializeField]
    public bool Invulnerable = false;

    [SerializeField]
    protected float InvulnerableTime = 0.1f;

    public void TakeDamage(int damage)
    {
        if (Invulnerable) return;

        Health -= damage;

        if (Health <= 0)
            Destroy(gameObject);

        Invulnerable = true;

        StartCoroutine(MakeObjectVurnerable(InvulnerableTime));
    }
    IEnumerator MakeObjectVurnerable(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);

        Invulnerable = false;
    }
}
