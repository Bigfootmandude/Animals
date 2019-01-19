using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Percentage 
{
    public const float MIN = 0;
    public const float MAX = 100.0f;

    private float currentValue;

    public Percentage(float initialValue)
    {
        currentValue = initialValue;
    }

    public void setCurrentValue(float newValue)
    {
        verifyInput(newValue);
        currentValue = newValue;
    }

    public float getCurrentValue()
    {
        return currentValue;
    }

    public bool addVal(float val)
    {
        currentValue += val;

        if(currentValue > MAX)
        {
            currentValue = MAX;
            return true;
        }

        if(currentValue < MIN)
        {
            currentValue = MIN;
            return true;
        }

        return false;
    }

    private void verifyInput(float input)
    {
        if ((input < MIN) || (input > MAX))
            throw new System.ArgumentException("Percentages must be between 0 and 100.");
    }
}
