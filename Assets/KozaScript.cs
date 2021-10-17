using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KozaScript : MonoBehaviour
{
    public Text Button1Text;
    public Text Button2Text;
    public Text Button3Text;
    public Text Button4Text;

    public Text Label1Text;
    public Text Label2Text;
    public Text Label3Text;
    public Text Label4Text;

    public GameObject Koza;
    public GameObject FloatingPointsAsset;

    public int Button1Cost;
    public int Button2Cost;
    public int Button3Cost;
    public int Button4Cost;

    public int Points;
    public int PointsA;
    public int PointsB;
    public int PointsC;
    public float PointsD;

    private SaveGame SaveGame;

    private void Start()
    {
        try
        {
            SaveGame = SaveGame.Load();
        }
        catch
        {
            SaveGame = new SaveGame();
        }

        UpdatePoints();
    }

    private void UpdatePoints()
    {
        Label1Text.text = $"Punkty: {Points}";
        Label2Text.text = $"Label A: {PointsA}";
        Label3Text.text = $"Label B: {PointsB}";
        Label4Text.text = $"Label C: {PointsC}/{PointsD} s";
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Button1Click() { }
    void Button2Click() { }
    void Button3Click() { }
    void Button4Click() { }
}
