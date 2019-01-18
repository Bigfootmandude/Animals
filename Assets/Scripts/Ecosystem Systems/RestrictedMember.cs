using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Allows for "constant" members of a class, that can only have a get method => value(), and no setter.
/// </summary>
/// <typeparam name="T"></typeparam>
public class RestrictedMember<T>
{
    private T member;

    public RestrictedMember(T member)
    {
        this.member = member;
    }

    public T value()
    {
        return member;
    }
}
