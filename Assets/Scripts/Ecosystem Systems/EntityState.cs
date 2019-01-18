using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityState 
{
    public string stateName = "DefaultState";
    public string stateDescription = "This state contains no information.";
    public LivingEntity entity { get; }

    public float minDuration;
    public float maxDuation;

    public bool debugFlag = true;

    public EntityState(LivingEntity entity)
    {
        this.entity = entity;
       
    }

    public virtual  void OnEnterState()
    {

    }

    public virtual void OnExitState()
    {

    }

    public virtual void _debug(string message)
    {
        if (debugFlag) Debug.Log(message);
    }
}
