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
            attackable.FirstWeapon.FirstAttack.Attack();

        if (Input.GetMouseButtonDown(1))
            attackable.SecondWeapon.SecondAttack.Attack();

        if (Input.GetKeyDown(KeyCode.Space))
            Dash();

        if (Input.GetKeyDown(KeyCode.G))
            Test();
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
            attackable.Attack();
    }

    protected override void Dash()
    {
        if (dashable)
            StartCoroutine(dashable.Dash());

    }

    void Test()
    {
        Debug.Log(ArrayOfRooms.singleton.GetRoom(LocationType.LushCaves, RoomType.FightSmall).name);
    }
}
