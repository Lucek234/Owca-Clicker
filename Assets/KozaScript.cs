using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KozaScript : ZwierzeScript
{


    //private void UpdatePoints()
    //{
    //    Label1Text.text = $"Punkty: {Points}";
    //    Label2Text.text = $"Label A: {PointsA}";
    //    Label3Text.text = $"Label B: {PointsB}";
    //    Label4Text.text = $"Label C: {PointsC}/{PointsD} s";
    //}


    public override int ZwierzeDeltaPoints => Button1Level * 50 * (1 + Button3Level);

    public override int Points
    {
        get => SaveGame.Points;
        set => SaveGame.Points = value;
    }

    SaveGame SaveGame => SaveGame.Instance;
    public override int Button1Cost => 5000*(int)Mathf.Pow(2, Button1Level);
    public override string Button1LabelText => $"Dokup kolejną Kozę, Pożeracza Światów\n(cena: {Button1Cost} p)";
    public override string Button2LabelText => $"Dokup kolejną Kozę, Pożeracza Światów\n(cena: {Button2Cost} p)";
    public override string Button3LabelText => $"Dokup kolejną Kozę, Pożeracza Światów\n(cena: {Button3Cost} p)";
    public override string Button4LabelText => $"Dokup kolejną Kozę, Pożeracza Światów\n(cena: {Button4Cost} p)";
    public override string Label1Text => $"Punkty: {Points}";
    public override string Label2Text => $"Kozy, Pożeracze Światow: {Button1Level}";
    public override string Label3Text => $"Kozy, Pożeracze Światow: {Button3Level}";
    public override string Label4Text => $"Kozy, Pożeracze Światow: {Button2Level}/{Button4Level}";

    //TODO: Naprawić niedzialajacy przycisk i zapis gry.
    public override int Button1Level { get=>SaveGame.KozaLevel1; set=>SaveGame.KozaLevel1=value; }
    public override int Button2Level { get=>SaveGame.KozaLevel2; set=>SaveGame.KozaLevel2=value; }
    public override int Button3Level { get=>SaveGame.KozaLevel3; set=>SaveGame.KozaLevel3=value; }
    public override int Button4Level { get=>SaveGame.KozaLevel4; set=>SaveGame.KozaLevel4=value; }

}

