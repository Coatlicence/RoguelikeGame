using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] public int Damage;

    [SerializeField] public BoxCollider Collider;

    private void Start()
    {
        Collider = GetComponent<BoxCollider>();

        if (!Collider) throw new System.Exception("Weapon doesnt have BoxCollider");
    }
}
