using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPointsService
{
    public static AutoPointsService Instance { get; } = new AutoPointsService();

    private AutoPointsService()
    {

    }


    List<AutoAnimal> AnimalsToUpdate => SaveGame.Instance.AnimalsToUpdate;

    // Update is called once per frame
    public void Update(float deltaTime)
    {
        foreach(var animal in AnimalsToUpdate)
        {
            animal.Timer += Time.deltaTime;
            Debug.Log($"Animal update: {animal.AnimalName}");
        }
    }

    public int GetAutoPoints()
    {
        var totalPoints = 0;
        foreach(var animal in AnimalsToUpdate)
        {
            Debug.Log($"{animal.AnimalName} {animal.Timer}");
            if (animal.Timer < animal.AutoTime) continue;
            totalPoints += animal.AutoPoints;
            animal.Timer = 0;
        }
        return totalPoints;
    }

    public float GetTimer(string name)
    {
        foreach(var animal in AnimalsToUpdate)
        {
            if (animal.AnimalName != name) continue;
            return animal.Timer;
        }
        return 0;
    }

    public void UpdateAnimal(string name, int autoPoints, float autoTime)
    {
        if (name == null) return;

        AutoAnimal autoAnimal = null;
        foreach(var animal in AnimalsToUpdate)
        {
            if (animal.AnimalName == name) autoAnimal = animal;
        }

        if(autoAnimal == null)
        {
            AnimalsToUpdate.Add(new AutoAnimal
            {
                AnimalName = name,
                AutoPoints = autoPoints,
                AutoTime = autoTime
            });
        }
        else
        {
            autoAnimal.AutoPoints = autoPoints;
            autoAnimal.AutoTime = autoTime;
        }
    }
}
