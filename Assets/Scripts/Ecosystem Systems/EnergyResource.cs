using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnergyResource
{
    public event EventHandler<EnergyEvent> LowEnergy;
    public event EventHandler<EnergyEvent> HighEnergy;
    public event EventHandler<EnergyEvent> NoEnergy;
    public event EventHandler<EnergyEvent> FullEnergy;

    private RestrictedMember<float> MAX;
    private RestrictedMember<float> MIN;

    private float lowEnergyThreshold;
    private float highEnergyThreshold;

    private float currentValue;


    public EnergyResource(float maximum)
    {
        MAX = new RestrictedMember<float>(maximum);
        MIN = new RestrictedMember<float>(0);
        currentValue = MAX.value();
        this.lowEnergyThreshold = 0.2f * MAX.value();
        this.highEnergyThreshold = 0.8f * MAX.value();
    }

    public EnergyResource(float maximum, float lowEnergyThreshold, float highEnergyThreshold)
    {
        MAX = new RestrictedMember<float>(maximum);
        MIN = new RestrictedMember<float>(0);
        currentValue = MAX.value();
        this.lowEnergyThreshold = lowEnergyThreshold;
        this.highEnergyThreshold = highEnergyThreshold;
    }



    public float getMAX()
    {
        return MAX.value();
    }

    public bool gainEnergy(float energyAmount)
    {
        if (energyAmount < 0)
        {
            throw new System.ArgumentException("energyAmount should always be positive.");
        }
        return addEnergy(energyAmount);
    }

    public bool expendEnergy(float energyAmount)
    {
        if (energyAmount < 0)
        {
            throw new System.ArgumentException("energyAmount should always be positive.");
        }
        return addEnergy(-energyAmount);
    }

    public float getCurrentEnergy()
    {
        return currentValue;
    }

    /// <summary>
    /// Returns true if the adding energy exceeds either min or max, and sets the current value to max.
    /// Otherwise adds normally, return fals
    /// </summary>
    /// <param name="energyAmount"></param>
    /// <returns></returns>
    private bool addEnergy(float energyAmount)
    {
        bool hitCap = false;
        float oldEnergy = currentValue;
        currentValue += energyAmount;
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


        checkForEvents(oldEnergy);
        return hitCap;
    }

    private void checkForEvents(float oldEnergy)
    {
        //check to see if we are out of energy
        if (currentValue == MIN.value())
        {
            raiseEvent(NoEnergy, "Energy resource is empty.");
        }

        //check to see if the energy resource if full
        if(currentValue == MAX.value())
        {
            raiseEvent(FullEnergy, "Energy resource is full.");
        }

        //check to see if we crossed the high energy threshold
        if((oldEnergy < highEnergyThreshold)&&( currentValue >= highEnergyThreshold))
        {
            raiseEvent(HighEnergy, "Energy resource is high.");
        }

        if((oldEnergy > lowEnergyThreshold)&& (currentValue <= lowEnergyThreshold))
        {
            raiseEvent(LowEnergy, "Energy resource is low.");
        }
    }

    private void raiseEvent(EventHandler<EnergyEvent> energyEventHandler, string message)
    {
        EnergyEvent energyEvent = new EnergyEvent();
        energyEvent.Message = message;
        energyEvent.TimeReached = Time.fixedTime;
        energyEventHandler?.Invoke(this, energyEvent);
    }




}
