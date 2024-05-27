using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    [SerializeField]
    private float Speed;

    public float GetSpeed() { return Speed; }

    public void SetSpeed(float speed)
    {
        if (speed <= 0)
        {
            Debug.LogError("speed must be more than 0");
        }

        Speed = speed;
    }


    [SerializeField]
    private Rigidbody body;

    [SerializeField]
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

        body.velocity = Speed * Time.fixedDeltaTime * new Vector3(inputHorizontal - inputVertical, 0, inputHorizontal + inputVertical);
    }
}
