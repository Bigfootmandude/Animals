using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))] //we can use the the move command build into the character controller
public abstract class base_character : MonoBehaviour
{

    public float baseMovespeed = 3.0f;
    public float baseJumpStrength = 3.0f;
    public const float GRAVITY = -9.81f;


    //Any character specific items can go here.
}
