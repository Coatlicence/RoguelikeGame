using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAttack 
{
    protected Command PressHandler;
    protected Command HoldHandler;
    protected Command ReleaseHandler;
}




//[SerializeField] protected int _MinDamage;
//[SerializeField] protected int _MaxDamage;
//[SerializeField] protected int _Range;
//[SerializeField] protected int _DelayTime;
//[SerializeField] protected int _KnockBack;