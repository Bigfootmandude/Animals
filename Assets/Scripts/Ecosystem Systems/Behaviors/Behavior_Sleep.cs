using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior_Sleep : BehaviorCore
{

    public float sleepyRegenerationRate = -0.1f;
    public float sleepyLevelThreshold = 0;

    public Behavior_Sleep(AnimalEntity animal, AnimalAI animalAi)
    {
        behaviorName = "Sleep.";
        behaviorDescription = "The animal will sleep for the sleep until the sleepyLevel is below the threshold, unless interupted.";
        this.animalAi = animalAi;
        this.animal = animal;
    }

    public override void startBehaviorActions()
    {

    }

    public override void endingBehaviorActions()
    {
        if (topLevelBehavior == null)
            animalAi.handleTopLevelBehaviors();
        else
        {
            topLevelBehavior.handleSecondaryBehaviors();
        }
    }

    public override void executeBehaviorActions()
    {
        animalAi.sleepyLevel.addVal(sleepyRegenerationRate);
        if(animalAi.sleepyLevel.getCurrentValue() <= sleepyLevelThreshold)
        {
            endingBehaviorActions();
        }
    }

    public override void handleSecondaryBehaviors()
    {
        
    }
}
