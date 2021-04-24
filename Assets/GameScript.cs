using System;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public int Points = 0;
    public int CenaOwcy = 1;
    public int LiczbaOwiec = 1;
    public int CenaLepszychNozyczek = 50;
    public int LiczbaLepszychNozyczek = 1;
    public int CenaAutoNozyczek = 100;
    public int LiczbaNozyczek = 0;
    public int CenaLepszychAutoNozyczek = 100;

    internal object BuyLepszeAutoNozyczki()
    {

        if (Points < CenaAutoNozyczek) return CenaAutoNozyczek;
        Points -= CenaAutoNozyczek;
        LiczbaAutoNozyczek += 1;
        CenaAutoNozyczek += 4 * CenaAutoNozyczek;
        UpdatePoints();
        return CenaAutoNozyczek;
    }

    public int CenaNozyczek = 10;
    public int LiczbaAutoNozyczek = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float timer = 0;
    float NozyczkiTime => 9.5f / (1 + LiczbaAutoNozyczek) + 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (timer >= NozyczkiTime)
        {
            timer = 0;
            NozyczkiUpdate();
        }

        timer += Time.deltaTime;
    }

    internal int BuyAuto()
    {
        if (Points < CenaAutoNozyczek) return CenaAutoNozyczek;
        Points -= CenaAutoNozyczek;
        LiczbaAutoNozyczek += 1;
        CenaAutoNozyczek += 4 * CenaAutoNozyczek;
        UpdatePoints();
        return CenaAutoNozyczek;
    }

    public int BuyNozyczki()
    {
        if (Points < CenaLepszychNozyczek) return CenaLepszychNozyczek;
        Points -= CenaLepszychNozyczek;
        LiczbaLepszychNozyczek += 1;
        CenaLepszychNozyczek *= 4;
        UpdatePoints();
        return CenaLepszychNozyczek;
    }

    int AddPointsAutoNozyczki => 1 * LiczbaNozyczek * LiczbaLepszychNozyczek;

    void NozyczkiUpdate()
    {
        if (LiczbaNozyczek == 0) return;
        Points += AddPointsAutoNozyczki;
        UpdatePoints();
        Instantiate(NozyczkiAsset, Canvas.transform);
        ShowAddPoints(AddPointsAutoNozyczki, new Color(255, 0, 255));
    }

    internal int BuySheep()
    {
        if (CenaOwcy <= Points)
        {
            LiczbaOwiec += 1;
            Points -= CenaOwcy;
            CenaOwcy *= 4;
        }

        UpdatePoints();
        return CenaOwcy;
    }


    internal int KupNozyczki()
    {
        if (CenaNozyczek <= Points)
        {
            Points -= CenaNozyczek;
            CenaNozyczek *= 3;
            LiczbaNozyczek += 1;
            UpdatePoints();
        }
        return CenaNozyczek;
    }

    public void OnSheepClick()
    {
        var addPoints = LiczbaLepszychNozyczek * LiczbaOwiec;
        Points +=addPoints;
        UpdatePoints();
        ShowAddPoints(addPoints, Color.white);
    }

    void ShowAddPoints(int addPoints, Color color, int fontSize=30)
    {
        var floating = Instantiate(FloatingPointsAsset, Canvas.transform);
        var textComp = floating.GetComponent<Text>();
        textComp.text = $"+{addPoints}p";
        textComp.color = color;
        textComp.fontSize = fontSize;
        var dx = UnityEngine.Random.Range(-100, 100);
        var dy = UnityEngine.Random.Range(-50, 100);
        var randPos = new Vector2(dx,dy);
        floating.GetComponent<RectTransform>().anchoredPosition = SheepElement.GetComponent<RectTransform>().anchoredPosition + randPos;
    }

    public GameObject SheepElement;
    public GameObject PointsElement;
    public GameObject LiczbaOwiecElement;
    public GameObject AutoNozyczkiElement;
    public GameObject Canvas;

    public GameObject NozyczkiAsset;
    public GameObject FloatingPointsAsset;

    void UpdatePoints()
    {
        PointsElement.GetComponent<Text>().text = $"Punkty: {Points}p";
        LiczbaOwiecElement.GetComponent<Text>().text = $"Liczba owiec: {LiczbaOwiec}";
        AutoNozyczkiElement.GetComponent<Text>().text = $"Auto Nożyczki: +{AddPointsAutoNozyczki}p/{NozyczkiTime.ToString("n1")}s";
    }
}
