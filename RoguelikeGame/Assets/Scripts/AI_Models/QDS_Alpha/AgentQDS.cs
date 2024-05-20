using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using UnityEngine.EventSystems;

public class AgentQDS : Agent
{
    //[SerializeField] [Tooltip("")]
    //StandartController _Controller;

    [SerializeField] [Tooltip("")]
    IDamagable damagable;

    [SerializeField] [Tooltip("")]
    Movable movable;

    [SerializeField] [Tooltip("")]
    Dashable dashable;

    [SerializeField] [Tooltip("")]
    IAttackable attackable;

    [SerializeField] [Tooltip("")]
    CloneOneHP clone;

    public bool block = false;


    private void Start()
    {
        damagable   = GetComponent<IDamagable>();
        movable     = GetComponent<Movable>();
        dashable    = GetComponent<Dashable>();
        attackable  = GetComponent<IAttackable>();
        clone       = GetComponent<CloneOneHP>();
    }

    /// <summary>
    /// C - Continous; D - Discrete
    /// 
    /// 0C - Vertical Move
    /// 1C - Horizontal Move
    /// 
    /// 0D - Dash
    /// 1D - Attack Left
    /// 2D - Attack Right
    /// 3D - Activate fully copy and divide equally hp
    /// </summary>
    /// <param name="actionsOut"></param>
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        float v = 0, h = 0;

        int dash = 0, attackl = 0, attackr = 0;
        int clone1 = 0;

        if (!block)
        {
            v = Input.GetAxis("Vertical");
            h = Input.GetAxis("Horizontal");

            if (Input.GetMouseButtonDown(0)) attackl = 1;
            if (Input.GetMouseButtonDown(1)) attackr = 1;

            if (Input.GetKeyDown(KeyCode.Space)) dash = 1;
            if (Input.GetKeyDown(KeyCode.F)) clone1 = 1;
        }

        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = v;
        continuousActionsOut[1] = h;

        var discreteActionOut = actionsOut.DiscreteActions;
        discreteActionOut[0] = dash;
        discreteActionOut[1] = attackl;
        discreteActionOut[2] = attackr;
        discreteActionOut[3] = clone1;
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        var cact = actions.ContinuousActions;

        movable.Move(cact[1], cact[0]);
        
        ///-------------------------------------------------
        var dact = actions.DiscreteActions;

        if (dact[0] > 0)
            StartCoroutine(dashable.Dash());

        if (dact[1] > 0)
        {
            //attackable.FirstWeapon.FirstAttack.Attack();
            Debug.Log("Attacked with 1 weapon and 1 attack");
        }

        if (dact[2] > 0)
        {
            //attackable.SecondWeapon.SecondAttack.Attack();
            Debug.Log("Attacked with 2 weapon and 2 attack");
        }

        if (dact[3] > 0)
            clone.Clone();
    }
}
