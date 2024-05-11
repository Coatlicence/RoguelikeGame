using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StandartController : MonoBehaviour
{
    [SerializeField] protected float _InteractionRadius = 4f;

    [SerializeField] protected Movable movable;
    [SerializeField] protected IAttackable attackable;
    [SerializeField] protected Dashable dashable;



    private void Awake()
    {
        movable = GetComponent<Movable>();
        attackable = GetComponent<IAttackable>();
    }

    protected abstract void Move();
    protected abstract void AttackLeft();
    protected abstract void AttackRight();
    protected abstract void Dash();

    protected void Interact()
    {
        var colliders = Physics.OverlapSphere(transform.position, _InteractionRadius);
        
        foreach (var collider in colliders)       
            if (collider.TryGetComponent<IInteractable>(out var interactable))
            {
                interactable.Interact(this);
                break;
            }
    }
}
