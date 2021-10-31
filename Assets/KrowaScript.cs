using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KrowaScript : ZwierzeScript
{

    public override int ZwierzeDeltaPoints => Button1Level * BazowePunkty * (1 + Button3Level);

    public override int Button1Cost => 1000 * (int)Mathf.Pow(2, Button1Level);
    public override int Button2Cost => 1000 * (int)Mathf.Pow(2, Button2Level);
    public override int Button3Cost => 1000 * (int)Mathf.Pow(2, Button3Level);
    public override int Button4Cost => 1000 * (int)Mathf.Pow(2, Button4Level);
    public override int AutoPoints => Button2Level * 25;
    public override float AutoTime => 0.5f + 9.5f / (Button4Level + 1);
    public override string Button1LabelText => $"Dokup kolejną krowe\n(cena: {Button1Cost} p)";
    public override string Button2LabelText => $"Dokup automatyczną dojarkę\n(cena: {Button2Cost} p)";
    public override string Button3LabelText => $"Ulepsz mleko\n(cena: {Button3Cost} p)";
    public override string Button4LabelText => $"Lepsze pole\n(cena: {Button4Cost} p)";
    public override string Label1Text => $"Punkty: {Points}";
    public override string Label2Text => $"Krowy: {Button1Level}";
    public override string Label3Text => $"Lepsza pasza: {Button3Level}";
    public override string Label4Text => $"Autodojarka: {AutoPoints} p/{AutoTime:0.00} s";

    //TODO: Naprawić niedzialajacy przycisk i zapis gry.
    public override int Button1Level { get => SaveGame.KrowaLevel1; set => SaveGame.KrowaLevel1 = value; }
    public override int Button2Level { get => SaveGame.KrowaLevel2; set => SaveGame.KrowaLevel2 = value; }
    public override int Button3Level { get => SaveGame.KrowaLevel3; set => SaveGame.KrowaLevel3 = value; }
    public override int Button4Level { get => SaveGame.KrowaLevel4; set => SaveGame.KrowaLevel4 = value; }

}
