using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EntityState_Dead : EntityState
{
    //TODO: Default pose for being dead set on run


    public EntityState_Dead(LivingEntity entity): base(entity)
    {
        stateName = "Dead";
        stateDescription = "The living entity is deceased.";
    }

    public override void OnEnterState()
    {
        //at this point the energy decay rate should increase as it decomposes. 
        //it should not be able to do anything - so the behavior should be null
        entity.enableBehaviors = false;
        entity.currentState = null;
        entity.energyDecayRate *= 2; //decay energy
        entity.energy.NoResource += finishedDecay;  //when the entity is completely out of energy, it has decayed.
    }

    public void finishedDecay(object sender, EventArgs e)
    {
        OnExitState();
    }

    //after the entity is dead, on exiting dead it should de-spawn.
    public override void OnExitState()
    {
        _debug("Entity: " + entity.name + " has died.");
        UnityEngine.Object.Destroy(entity.gameObject);
        
    }

    
}
