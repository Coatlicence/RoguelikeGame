using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerController : StandartController
{
    protected void FixedUpdate()
    {
        if (movable != null)
            Move();

    }

    protected void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Attack();

        if (Input.GetKeyDown(KeyCode.Space))
            Dash();

        Debug.Log(GetComponent<Rigidbody>().velocity);
    }
    protected override void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        movable.Move(x, z);
    }

    protected override void Attack()
    {
        if (attackable != null)
            attackable.Attack(0);
    }

    protected override void Dash()
    {
        if (dashable)
            StartCoroutine(dashable.Dash());

    }
}
