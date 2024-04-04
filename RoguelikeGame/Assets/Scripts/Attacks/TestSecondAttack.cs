using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSecondAttack : BaseAttack
{
    public override void Attack()
    {
        var colls = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2);

        foreach (var element in colls)
        {
            if (element.TryGetComponent<IDamagable>(out IDamagable damagable))
            {
                damagable.TakeDamage(20);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
