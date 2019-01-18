using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlantEntity : LivingEntity
{
    public float lightRequirement;      //how much light must be visible for the plant to grow.
    public float waterRequirement;      //how far the plant must be from water for the plant to grow.


    public List<LivingEntity> predators = new List<LivingEntity>();
    //inits a default plant state
    public override void init()
    {
        name = "Default Plant";
        description = "Default description.";
        energy = new EnergyResource(20);
        healthPoints = new EnergyResource(30);
        energyDecayRate = 0.01f;
        activeBehavior = new Behavior_None();
        topLevelBehaviors.Add(activeBehavior);
        currentState = new EntityState_Empty();
        entityStates.Add(currentState);
        lightRequirement = 1;
        waterRequirement = 100;
        maximumSize = 10;
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
