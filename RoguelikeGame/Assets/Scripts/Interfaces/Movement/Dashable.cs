using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashable : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Rigidbody body;

    [Header("Properties")]
    protected bool CanDash = true;
    public bool isDashing { get; private set; } = false;
    [SerializeField]
    protected float DashPower = 24f;
    [SerializeField]
    protected float DashingTime = 0.2f;
    [SerializeField]
    protected float DashingCooldown = 1f;


    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
    public IEnumerator Dash()
    {
        Debug.Log(CanDash);

        if (body == null) yield break;

        if (!CanDash) yield break;

        CanDash = false;
        isDashing = true;
        body.velocity = new Vector3(body.velocity.x * DashPower, body.velocity.y, body.velocity.z * DashPower);

        yield return new WaitForSeconds(DashingTime);

        isDashing = false;

        yield return new WaitForSeconds(DashingCooldown);

        CanDash = true;
    }
}
