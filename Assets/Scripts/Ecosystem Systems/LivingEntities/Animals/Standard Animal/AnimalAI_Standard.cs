using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAI_Standard : AnimalAI
{


    public override void init()
    {
        base.init();
        Behavior_Survive survive = new Behavior_Survive(animal, this);
        Behavior_Sleep sleep = new Behavior_Sleep(animal, this);




        topLevelBehaviors.Add(typeof(Behavior_Sleep), sleep);
        topLevelBehaviors.Add(typeof(Behavior_Survive), survive);
    }
}
