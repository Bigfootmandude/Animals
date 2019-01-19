using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Resource 
{


    public string resourceName = "GenericResource";
    public event EventHandler<ResourceEvent> LowResource;
    public event EventHandler<ResourceEvent> HighResource;
    public event EventHandler<ResourceEvent> NoResource;
    public event EventHandler<ResourceEvent> FullResource;

    private RestrictedMember<float> MAX;
    private RestrictedMember<float> MIN;

    private float lowResourceThreshold;
    private float highResourceThreshold;

    private float currentValue;


    public Resource(float maximum)
    {
        MAX = new RestrictedMember<float>(maximum);
        MIN = new RestrictedMember<float>(0);
        currentValue = MAX.value();
        this.lowResourceThreshold = 0.2f * MAX.value();
        this.highResourceThreshold = 0.8f * MAX.value();
    }

    public Resource(float maximum, float lowResourceThreshold, float highResourceThreshold)
    {
        MAX = new RestrictedMember<float>(maximum);
        MIN = new RestrictedMember<float>(0);
        currentValue = MAX.value();
        this.lowResourceThreshold = lowResourceThreshold;
        this.highResourceThreshold = highResourceThreshold;
    }

    public Resource(float maximum, float lowResourceThreshold, float highResourceThreshold, string resourceName)
    {
        MAX = new RestrictedMember<float>(maximum);
        MIN = new RestrictedMember<float>(0);
        currentValue = MAX.value();
        this.lowResourceThreshold = lowResourceThreshold;
        this.highResourceThreshold = highResourceThreshold;
        this.resourceName = resourceName;
    }



    public float getMAX()
    {
        return MAX.value();
    }

    public bool gainResource(float resourceAmount)
    {
        if (resourceAmount < 0)
        {
            throw new System.ArgumentException("ResourceAmount should always be positive.");
        }
        return addResource(resourceAmount);
    }

    public bool expendResource(float resourceAmount)
    {
        if (resourceAmount < 0)
        {
            throw new System.ArgumentException("ResourceAmount should always be positive.");
        }
        return addResource(-resourceAmount);
    }

    public float getCurrentResource()
    {
        return currentValue;
    }

    /// <summary>
    /// Removes a certain amount of resouce, up to resourceAmount. 
    /// </summary>
    /// <param name="resourceAmount"></param>
    /// <returns>Amount of energy stolen</returns>
    public float stealResource(float resourceAmount)
    {
        float preTheftValue = currentValue;
        return (addResource(-resourceAmount) ? currentValue : resourceAmount);
    }

    /// <summary>
    /// Returns true if the adding Resource exceeds either min or max, and sets the current value to max.
    /// Otherwise adds normally, return fals
    /// </summary>
    /// <param name="ResourceAmount"></param>
    /// <returns></returns>
    private bool addResource(float resourceAmount)
    {
        bool hitCap = false;
        float oldResource = currentValue;
        currentValue += resourceAmount;
        if (currentValue >= MAX.value())
        {
            currentValue = MAX.value();
            hitCap = true; ;
        }
        if (currentValue <= MIN.value())
        {
            currentValue = MIN.value();
            hitCap = true;
        }


        checkForEvents(oldResource);
        return hitCap;
    }

    private void checkForEvents(float oldResource)
    {
        //check to see if we are out of Resource
        if (currentValue == MIN.value())
        {
            raiseEvent(NoResource, resourceName + " is empty.");
        }

        //check to see if the Resource resource if full
        if (currentValue == MAX.value())
        {
            raiseEvent(FullResource, resourceName + " is full.");
        }

        //check to see if we crossed the high Resource threshold
        if ((oldResource < highResourceThreshold) && (currentValue >= highResourceThreshold))
        {
            raiseEvent(HighResource, resourceName + " is high.");
        }

        if ((oldResource > lowResourceThreshold) && (currentValue <= lowResourceThreshold))
        {
            raiseEvent(LowResource, resourceName + " is low.");
        }
    }

    private void raiseEvent(EventHandler<ResourceEvent> resourceEventHandler, string message)
    {
        EventHandler<ResourceEvent> handler = resourceEventHandler;
        //Debug.Log(message);
        ResourceEvent resourceEvent = new ResourceEvent();
        resourceEvent.Message = message;
        resourceEvent.TimeReached = Time.fixedTime;
        handler?.Invoke(this, resourceEvent);
    }




}


