using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KozaScript : ZwierzeScript
{

    public override int ZwierzeDeltaPoints => Button1Level * BazowePunkty * (1 + Button3Level);

    public override int Button1Cost => 5000*(int)Mathf.Pow(2, Button1Level);
    public override int Button2Cost => 5000*(int)Mathf.Pow(2, Button2Level);
    public override int Button3Cost => 5000*(int)Mathf.Pow(2, Button3Level);
    public override int Button4Cost => 5000*(int)Mathf.Pow(2, Button4Level);
    public override int AutoPoints => Button2Level * 50;
    public override float AutoTime => 0.5f + 9.5f / (Button4Level + 1);
    public override string Button1LabelText => $"Dokup kolejną Kozę, Pożeracza Światów\n(cena: {Button1Cost} p)";
    public override string Button2LabelText => $"Dokup AutoMatyczne zbieranie sera\n(cena: {Button2Cost} p)";
    public override string Button3LabelText => $"Dokup lepsze światy\n(cena: {Button3Cost} p)";
    public override string Button4LabelText => $"Dokup wyższe góry\n(cena: {Button4Cost} p)";
    public override string Label1Text => $"Punkty: {Points}";
    public override string Label2Text => $"Kozy, Pożeracze Światow: {Button1Level}";
    public override string Label3Text => $"Lepszość światów: {Button3Level}";
    public override string Label4Text => $"Auto serek: {AutoPoints} p/{AutoTime:0.00} s";

    //TODO: Naprawić niedzialajacy przycisk i zapis gry.
    public override int Button1Level { get=>SaveGame.KozaLevel1; set=>SaveGame.KozaLevel1=value; }
    public override int Button2Level { get=>SaveGame.KozaLevel2; set=>SaveGame.KozaLevel2=value; }
    public override int Button3Level { get=>SaveGame.KozaLevel3; set=>SaveGame.KozaLevel3=value; }
    public override int Button4Level { get=>SaveGame.KozaLevel4; set=>SaveGame.KozaLevel4=value; }

}

