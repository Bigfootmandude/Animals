using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BehaviorStateException : Exception
{
    public BehaviorStateException(string message): base(message)
    {

    }
}
