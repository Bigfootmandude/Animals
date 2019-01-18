using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class LivingEntity : MonoBehaviour
{
    public string name = "Un-named living entity";
    public string description = "None.";

    public EnergyResource energy;
    public EnergyResource healthPoints;

    public float energyDecayRate = 0.05f;

    public List<BehaviorCore> topLevelBehaviors = new List<BehaviorCore>();
    public BehaviorCore activeBehavior;

    public List<EntityState> entityStates = new List<EntityState>();
    public EntityState currentState;

    public float maximumSize = 1;

    public abstract void init();

    public abstract void decayEnergy();

    public abstract void registerEnergyEvents();


}
