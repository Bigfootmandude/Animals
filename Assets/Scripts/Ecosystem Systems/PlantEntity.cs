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
        entityName = "Default Plant";
        entityDescription = "Default description.";
        energy = new Resource(20);
        healthPoints = new Resource(30);
        energyDecayRate = 0.01f;
        activeBehavior = new Behavior_None();
        currentState = new EntityState_Empty();
        entityStates.Add(currentState);
        lightRequirement = 1;
        waterRequirement = 100;
        maximumSize = 10;
    }

    public override void decayEnergy()
    {
        energy.expendResource(energyDecayRate);
    }

    public override void registerEnergyEvents()
    {
        energy.NoResource += OnNoEnergy;
        energy.FullResource += OnFullEnergy;
        energy.LowResource += OnLowEnergy;
        energy.HighResource += OnHighEnergy;
    }

    public virtual void OnNoEnergy(object sender, EventArgs e)
    {
        healthPoints.expendResource(energyDecayRate);
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

    public override void registerHealthEvents()
    {
        healthPoints.NoResource += OnNoHealthPoints;
        healthPoints.FullResource += OnFullHealthPoints;
        healthPoints.LowResource += OnLowHealthPoints;
        healthPoints.HighResource += OnHighHealthPoints;
    }

    

    public virtual void OnNoHealthPoints(object sender, EventArgs e)
    {
        currentState = new EntityState_Dead(this);
        currentState.OnEnterState();
    }

    public virtual void OnFullHealthPoints(object sender, EventArgs e)
    {

    }

    public virtual void OnLowHealthPoints(object sender, EventArgs e)
    {

    }

    public virtual void OnHighHealthPoints(object sender, EventArgs e)
    {

    }

    public override void OnBeingEaten(LivingEntity somePredator)
    {
        
    }
}
