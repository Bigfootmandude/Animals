using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(AnimalAI),typeof(CharacterController))]
public class AnimalEntity : LivingEntity
{
    public Material TEMP_testDeathMat;
    public float biteDamage = 1.0f;

    public List<LivingEntity> predators = new List<LivingEntity>();
    public List<LivingEntity> prey = new List<LivingEntity>();

    public AnimalAI animalAI;
    public CharacterController characterController;

    public bool enableDebug = true;
    
    public override void init()
    {
        //entityName = "Default Animal";
        //entityDescription = "Default description.";
        energy = new Resource(30);
        energy.resourceName = "Energy";
        healthPoints = new Resource(40);
        healthPoints.resourceName = "Health Points";
        energyDecayRate = 0.05f;
        currentState = new EntityState_Empty();
        entityStates.Add(currentState);
        maximumSize = 2;
        animalAI = gameObject.GetComponent<AnimalAI>();
        characterController = gameObject.GetComponent<CharacterController>();
    }

    void Start()
    {
        init();
        currentState = new EntityState_Alive(this);
    }



    void Update()
    {
        currentState.StateUpdate();
    }

    public override void OnBeingEaten(LivingEntity somePredator)
    {

    }

    public void _debug(string message)
    {
        if (enableDebug) Debug.Log(message);
    }
}
