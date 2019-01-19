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
        currentState = new EntityState_Empty();
        entityStates.Add(currentState);
        lightRequirement = 1;
        waterRequirement = 100;
        maximumSize = 10;
    }

    
    public override void OnBeingEaten(LivingEntity somePredator)
    {
        
    }
}
