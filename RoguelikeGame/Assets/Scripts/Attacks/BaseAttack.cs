using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAttack : MonoBehaviour
{
    [SerializeField] protected int _MinDamage;
    [SerializeField] protected int _MaxDamage;
    [SerializeField] protected int _Range;
    [SerializeField] protected int _DelayTime;
    [SerializeField] protected int _KnockBack;
    abstract public void Attack();
}