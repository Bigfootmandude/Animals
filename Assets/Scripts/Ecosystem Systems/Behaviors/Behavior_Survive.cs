using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior_Survive : BehaviorCore
{


    public Behavior_Survive(AnimalEntity animal, AnimalAI animalAi)
    {
        this.animal = animal;
        this.animalAi = animalAi;
        Behavior_FindFood findFood = new Behavior_FindFood();
        Behavior_FindMate findMate = new Behavior_FindMate();

        secondaryBehaviors.Add(typeof(Behavior_FindFood), findFood);
        secondaryBehaviors.Add(typeof(Behavior_FindMate), findMate);
    }

    public override void endingBehaviorActions()
    {
        
    }

    public override void executeBehaviorActions()
    {
        
    }

    public override void handleSecondaryBehaviors()
    {
        
    }

    public override void startBehaviorActions()
    {
        
    }
}
