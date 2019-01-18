using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimalEntity : LivingEntity
{


    public override void init()
    {
        name = "Default Animal";
        description = "Default description.";
        energy = new EnergyResource(30);
        healthPoints = new EnergyResource(40);
        energyDecayRate = 0.05f;
        activeBehavior = new Behavior_None();
        topLevelBehaviors.Add(activeBehavior);
        currentState = new EntityState_Empty();
        entityStates.Add(currentState);
        maximumSize = 2;
    }

    public override void decayEnergy()
    {
        energy.expendEnergy(energyDecayRate);
    }

    public override void registerEnergyEvents()
    {
        energy.NoEnergy += OnNoEnergy;
        energy.FullEnergy += OnFullEnergy;
        energy.LowEnergy += OnLowEnergy;
        energy.HighEnergy += OnHighEnergy;
    }

    public virtual void OnNoEnergy(object sender, EventArgs e)
    {

    }

    public virtual void OnFullEnergy(object sender, EventArgs e)
    {

    }

    public virtual void OnLowEnergy(object sender, EventArgs e)
    {

    }

    public virtual void OnHighEnergy(object sender, EventArgs e)
    {

    }

   
}
