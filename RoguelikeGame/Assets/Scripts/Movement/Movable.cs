using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    [SerializeField]
    private float Speed;

    private Rigidbody body;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    public void Move(float inputHorizontal, float inputVertical)
    {
        if (body == null)
        {
            Debug.Log("IMovable script cant find RigidBody");

            return;
        }

        inputHorizontal *= Speed * Time.fixedDeltaTime;
        inputVertical *= Speed * Time.fixedDeltaTime;

        body.velocity = new Vector3(inputHorizontal, 0, inputVertical);

        if (inputHorizontal == 0)
            body.velocity = new Vector3(0, body.velocity.y, body.velocity.z);

        if (inputVertical == 0)
            body.velocity = new Vector3(body.velocity.x, body.velocity.y, 0);


    }
}
