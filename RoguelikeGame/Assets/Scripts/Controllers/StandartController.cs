using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StandartController : MonoBehaviour
{
    [SerializeField] protected Movable movable;

    private void Awake()
    {
        movable = GetComponent<Movable>();

        Debug.Log("ok");
    }

    protected abstract void Move();


}
