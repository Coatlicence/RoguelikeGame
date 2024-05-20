using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents.Policies;
using UnityEngine;

[RequireComponent(typeof(IDamagable))]
public class CloneOneHP : BaseClone
{
    [SerializeField]
    IDamagable _Damagable;

    private void Awake()
    {
        _Damagable = GetComponent<IDamagable>();
    }

    public override GameObject Clone()
    {
        if (_Damagable.GetHealth() <= 1) 
            return null;

        GameObject clone = Instantiate(gameObject);

        clone.GetComponent<IDamagable>().SetMaxHealth(1);

        _Damagable.TakeDamage(1);

        Debug.Log("On Testing! Delete this line of code");
        clone.GetComponent<BehaviorParameters>().BehaviorType = BehaviorType.Default;

        clone.GetComponent<MeshRenderer>().material.color = new Color(0f, 0.4f, 1f, 0.2f);

        clone.GetComponent<AgentQDS>().block = true;

        clone.GetComponentInChildren<Camera>().enabled = false;

        return clone;
    }

    
}
