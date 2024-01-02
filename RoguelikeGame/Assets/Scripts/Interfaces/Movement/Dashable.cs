using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashable : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Rigidbody body;

    [SerializeField]
    private IDamagable damagable;
    
    public bool isDashing { get; private set; } = false;

    [Header("Properties")]
    [SerializeField]
    protected float DashPower = 5f;
    
    [SerializeField]
    protected float DashingTime = 0.15f;
    
    [SerializeField]
    protected float DashingCooldown = 1f;

    [SerializeField]
    protected int DashCountsMax = 2;

    protected int DashCountsCurrent = 2;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
    public IEnumerator Dash()
    {
        // Conditions
        if (body == null) yield break;

        if (DashCountsCurrent == 0) yield break;

        // Dash logic
        DashCountsCurrent--;

        body.velocity = new Vector3(Math.Sign(body.velocity.x) * DashPower, body.velocity.y, Math.Sign(body.velocity.z) * DashPower);

        isDashing = true;
        if (damagable) damagable.Invulnerable = true;

        // Refreshing
        yield return new WaitForSeconds(DashingTime);

        isDashing = false;
        if (damagable) damagable.Invulnerable = false;

        yield return new WaitForSeconds(DashingCooldown);

        DashCountsCurrent = DashCountsMax;
    }
}
