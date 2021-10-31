using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPointsService
{
    public static AutoPointsService Instance { get; } = new AutoPointsService();

    private AutoPointsService()
    {

    }

    public class AutoAnimal
    {
        public float Timer;
        public float AutoTime;
        public int AutoPoints;
        public string AnimalName;
    }

    List<AutoAnimal> AnimalsToUpdate = new List<AutoAnimal>();

    // Update is called once per frame
    public void Update(float deltaTime)
    {
        foreach(var animal in AnimalsToUpdate)
        {
            animal.Timer += Time.deltaTime;
        }
    }

    public int GetAutoPoints()
    {
        var totalPoints = 0;
        foreach(var animal in AnimalsToUpdate)
        {
            if (animal.Timer < animal.AutoTime) continue;
            totalPoints += animal.AutoPoints;
            animal.Timer = 0;
        }
        return totalPoints;
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
