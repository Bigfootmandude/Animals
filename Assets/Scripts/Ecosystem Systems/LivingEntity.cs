using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class LivingEntity : MonoBehaviour
{
    public string entityName = "Un-named living entity";
    public string entityDescription = "None.";

    public Resource energy;
    public Resource healthPoints;

    public float energyDecayRate = 0.05f;

    
    public BehaviorCore activeBehavior;

    public List<EntityState> entityStates = new List<EntityState>();
    public EntityState currentState;

    public float maximumSize = 1;

    public bool enableBehaviors = true;

    public abstract void init();

    public abstract void decayEnergy();

    public abstract void registerEnergyEvents();

    public abstract void registerHealthEvents();

    public abstract void OnBeingEaten(LivingEntity somePredator);


}
