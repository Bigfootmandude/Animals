using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ResourceEvent : EventArgs
{
    public float TimeReached;
    public string Message { get; set; }

}
