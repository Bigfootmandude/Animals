using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EntityState_Dead : EntityState
{
    //TODO: Default pose for being dead set on run

    public float rottingDuration = 10;  //after the living entity has no more energy to rot, this is how long it lasts

    private bool isRotting = false;

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
        entity.energyDecayRate *= 2; //decay energy
        entity.energy.NoResource += finishedDecay;  //when the entity is completely out of energy, it has decayed.
        entity.gameObject.GetComponent<Renderer>().material = ((AnimalEntity)entity ).TEMP_testDeathMat;

        //the if the energy is already empty, then the entity has already finished decaying and can now rot.
        if (entity.energy.getCurrentResource() == 0)
            isRotting = true;
    }

    public override void StateUpdate()
    {
        if (isRotting)
        {
            rottingDuration -= entity.energyDecayRate;
            if (rottingDuration < 0)
                OnExitState();
        } 
    }

    public void finishedDecay(object sender, EventArgs e)
    {
        isRotting = true;
    }

    //after the entity is dead, on exiting dead it should de-spawn.
    public override void OnExitState()
    {
        _debug("Entity: " + entity.name + " has died.");
        UnityEngine.Object.Destroy(entity.gameObject);
        
    }

    
}
