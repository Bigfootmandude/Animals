using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(AnimalAI))]
public class AnimalEntity : LivingEntity
{
    public List<LivingEntity> predators = new List<LivingEntity>();
    public List<LivingEntity> prey = new List<LivingEntity>();

    private AnimalAI animalAI;


    public override void init()
    {
        entityName = "Default Animal";
        entityDescription = "Default description.";
        energy = new Resource(30);
        healthPoints = new Resource(40);
        energyDecayRate = 0.05f;
        activeBehavior = new Behavior_None();
        currentState = new EntityState_Empty();
        entityStates.Add(currentState);
        maximumSize = 2;
        animalAI = gameObject.GetComponent<AnimalAI>();
    }

    public void executeActiveBehavior()
    {
        activeBehavior?.executeBehavior();
    }

    void Update()
    {
        executeActiveBehavior();
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

    public override void registerHealthEvents()
    {
        healthPoints.NoResource += OnNoHealthPoints;
        healthPoints.FullResource += OnFullHealthPoints;
        healthPoints.LowResource += OnLowHealthPoints;
        healthPoints.HighResource += OnHighHealthPoints;
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
