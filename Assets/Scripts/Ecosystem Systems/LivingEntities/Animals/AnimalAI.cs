using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(AnimalEntity))]
public class AnimalAI : MonoBehaviour
{
    public Dictionary<Type, BehaviorCore> topLevelBehaviors = new Dictionary<Type, BehaviorCore>();
    public BehaviorCore currentBehavior;
    public AnimalEntity animal;

    public Percentage aggressionLevel;
    public Percentage fearLevel;
    public Percentage satisfactionLevel;
    public Percentage sleepyLevel;

    void Start()
    {
        init();
        
    }

    public virtual void init()
    {
        currentBehavior = new Behavior_None();
        animal = gameObject.GetComponent<AnimalEntity>();
        aggressionLevel = new Percentage(0);
        fearLevel = new Percentage(0);
        satisfactionLevel = new Percentage(0);
        sleepyLevel = new Percentage(0);
    }

    void Update()
    {
        currentBehavior.executeBehavior();
    }

    public virtual void handleTopLevelBehaviors()
    {

    }


    public virtual void registerEnergyEvents()
    {
        animal.energy.NoResource += OnNoEnergy;
        animal.energy.FullResource += OnFullEnergy;
        animal.energy.LowResource += OnLowEnergy;
        animal.energy.HighResource += OnHighEnergy;
    }

    public virtual void registerHealthEvents()
    {
        animal.healthPoints.NoResource += OnNoHealthPoints;
        animal.healthPoints.FullResource += OnFullHealthPoints;
        animal.healthPoints.LowResource += OnLowHealthPoints;
        animal.healthPoints.HighResource += OnHighHealthPoints;
    }

    public virtual void OnNoEnergy(object sender, EventArgs e)
    {
        animal.healthPoints.expendResource(animal.energyDecayRate);
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
        animal.currentState = new EntityState_Dead(animal);
        animal.currentState.OnEnterState();
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

    public virtual void OnBeingEaten(LivingEntity somePredator)
    {

    }



}
