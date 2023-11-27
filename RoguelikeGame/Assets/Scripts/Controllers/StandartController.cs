using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StandartController : MonoBehaviour
{
    [SerializeField] protected Movable movable;
    [SerializeField] protected IAttackable attackable;
    [SerializeField] protected Dashable dashable;



    private void Awake()
    {
        movable = GetComponent<Movable>();
        attackable = GetComponent<IAttackable>();
    }

    protected abstract void Move();
    protected abstract void Attack();
    protected abstract void Dash();
}
