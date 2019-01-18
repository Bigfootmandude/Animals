using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviorCore 
{
    public string behaviorName = "Un-named behavior";
    public string behaviorDescription ="No description.";
    public List<BehaviorCore> secondaryBehaviors = new List<BehaviorCore>();
    public bool enabled = true;
    public enum behaviorState {starting, executing, ending, inactive}; //this will probably be replaced by a class
    public behaviorState currentState = behaviorState.inactive;

    public void startBehavior()
    {
        if (!enabled)
            throw new BehaviorStateException("Behavior is disabled, unabled to start behavior.");
        currentState = behaviorState.starting;
        startBehaviorActions();
    }

    public abstract void startBehaviorActions();
    

    public void executeBehavior()
    {
        if(!enabled)
            throw new BehaviorStateException("Behavior is disabled, unabled to execute behavior.");
        currentState = behaviorState.executing;
        executeBehaviorActions();
    }

    public abstract void executeBehaviorActions();

    public void endingBehavior()
    {
        if (!enabled)
            throw new BehaviorStateException("Behavior is disabled, unabled to end behavior.");
        currentState = behaviorState.ending;
        endingBehaviorActions();
    }

    public abstract void endingBehaviorActions();



}
