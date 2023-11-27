using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    [SerializeField]
    private float Speed;

    private Rigidbody body;

    private Dashable dashable;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        dashable = GetComponent<Dashable>();
    }

    public void Move(float inputHorizontal, float inputVertical)
    {
        if (dashable != null && dashable.isDashing) return;

        if (body == null)
        {
            Debug.Log("IMovable script cant find RigidBody");

            return;
        }

        body.velocity = new Vector3(inputHorizontal - inputVertical, 0, inputHorizontal + inputVertical)
                        * Speed * Time.fixedDeltaTime;
    }
}
