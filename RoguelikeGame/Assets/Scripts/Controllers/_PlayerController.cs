using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerController : StandartController
{
    protected void FixedUpdate()
    {
        if (movable != null) Move();
    }

    protected override void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        movable.Move(x, z);
    }
}
