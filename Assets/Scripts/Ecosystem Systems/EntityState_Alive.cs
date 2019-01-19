using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityState_Alive : EntityState
{
    public EntityState_Alive(LivingEntity entity) : base(entity)
    {

    }

    public override void StateUpdate()
    {
        if (entity.energy.getCurrentResource() >= entity.energyDecayRate)
        {
            entity.energy.expendResource(entity.energyDecayRate);
            return;
        }

        //steal the remaining energy, drain the remainder as health
        if (entity.energy.getCurrentResource() != 0)
            entity.healthPoints.expendResource(entity.energyDecayRate - entity.energy.stealResource(entity.energyDecayRate));
        else
            entity.healthPoints.expendResource(entity.energyDecayRate);
    
    }


}
