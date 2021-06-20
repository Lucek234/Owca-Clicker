using Assets;
using UnityEngine;
using UnityEngine.UI;

public class OwcaScript : MonoBehaviour
{
    public int Points
    {
        get => SaveGame.Points;
        set => SaveGame.Points = value;
    }

    public int LiczbaOwiec
    {
        get => SaveGame.LiczbaOwiec;
        set => SaveGame.LiczbaOwiec = value;
    }

    public int CenaOwcy => (int)Mathf.Pow(4, LiczbaOwiec - 1);
    public int CenaAutoMatycznychNozyczek => 10 * (int)Mathf.Pow(3, LiczbaAutoMatycznychNozyczek);
    public int CenaLepszychAutoNozyczek => 200 * (int)Mathf.Pow(4, LiczbaPrzyspieszenia);
    public int CenaNozyczek => 50 * (int)Mathf.Pow(4, LiczbaNozyczek-1);

    public int LiczbaAutoMatycznychNozyczek
    {
        get => SaveGame.LiczbaAutoMatycznychNozyczek;
        set => SaveGame.LiczbaAutoMatycznychNozyczek = value;
    }

    public int LiczbaNozyczek
    {
        get => SaveGame.LiczbaNozyczek;
        set => SaveGame.LiczbaNozyczek = value;
    }
    public SaveGame SaveGame = new SaveGame();


    public int LiczbaPrzyspieszenia
    {
        get => SaveGame.LiczbaPrzyspieszenia;
        set => SaveGame.LiczbaPrzyspieszenia = value;
    }
    private float timer = 0;

    private int AddPointsAutoNozyczki => 1  * LiczbaAutoMatycznychNozyczek;

    private float Przyspieszenie => 9.5f / (1 + LiczbaPrzyspieszenia) + 0.5f;


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


    private void Update()
    {
        if (timer >= Przyspieszenie)
        {
            timer = 0;
            NozyczkiUpdate();
        }

        timer += Time.deltaTime;
    }


    public void BuyLepszeNozyczki()
    {
        if (CenaNozyczek <= Points)
        {
            Points -= CenaNozyczek;
            //CenaNozyczek *= 3;
            LiczbaNozyczek += 1;
            UpdatePoints();
        }
        //return CenaNozyczek;
    }
    /// <summary>
    /// Funkcja dla drugiego guzika. Zwieksza liczbe punktow ktore automatycznie przyrastaja co ustalona ilość czasu.
    /// 
    /// Poczatkowa cena: 10 punktow.
    /// Cena zwieksza sie wedlug wzoru: 3^liczba_nozyczek * 10.
    /// </summary>
    public void BuyAutoMatyczneNozycki()
    {
        if (Points < CenaAutoMatycznychNozyczek) return;
        Points -= CenaAutoMatycznychNozyczek;
        LiczbaAutoMatycznychNozyczek += 1;
        UpdatePoints();
    }
  public void BuyLepszeAutoNozyczki()
    {
        if (Points < CenaLepszychAutoNozyczek) return;
        Points -= CenaLepszychAutoNozyczek;
        LiczbaPrzyspieszenia += 1;
        UpdatePoints();
    }


    private void NozyczkiUpdate()
    {
        if (LiczbaAutoMatycznychNozyczek == 0) return;
        Points += AddPointsAutoNozyczki;
        UpdatePoints();
        Instantiate(NozyczkiAsset, Canvas.transform);
        ShowAddPoints(AddPointsAutoNozyczki, new Color(255, 0, 255));
    }

    public void BuySheep()
    {
        if (CenaOwcy <= Points)
        {
            Points -= CenaOwcy;
            LiczbaOwiec += 1;
            //CenaOwcy *= 4;
        }

        

        UpdatePoints();
        //return CenaOwcy;
    }


    public void OnSheepClick()
    {
        int addPoints = LiczbaNozyczek * LiczbaOwiec;
        Points += addPoints;
        UpdatePoints();
        ShowAddPoints(addPoints, Color.white);
    }

    private void ShowAddPoints(int addPoints, Color color, int fontSize = 30)
    {
        GameObject floating = Instantiate(FloatingPointsAsset, Canvas.transform);
        Text textComp = floating.GetComponent<Text>();
        textComp.text = $"+{addPoints}p";
        textComp.color = color;
        textComp.fontSize = fontSize;
        int dx = UnityEngine.Random.Range(-100, 100);
        int dy = UnityEngine.Random.Range(-50, 100);
        Vector2 randPos = new Vector2(dx, dy);
        floating.GetComponent<RectTransform>().anchoredPosition = SheepElement.GetComponent<RectTransform>().anchoredPosition + randPos;
    }

    public GameObject SheepElement;
    public GameObject PointsElement;

    //public GameObject OwcaElement;
    public GameObject LiczbaOwiecElement;

    public GameObject AutoNozyczkiElement;
    public GameObject Canvas;

    public GameObject NozyczkiAsset;
    public GameObject FloatingPointsAsset;

    public Text BuyOwcaButtonText;
    public Text LepszeAutoNozyczkiText;
    public Text AutoMatyczneNozyczki;
    public Text LepszeNozyczkiText;
    public GameObject LiczbaNozyczekElement;
    private void UpdatePoints()
    {
        // Teksty przyciskow.
        BuyOwcaButtonText.text = $"Kup Owcę\n({CenaOwcy} punkty)"; ;
        AutoMatyczneNozyczki.text = $"Kup Auto Matyczne Nożyczki\n({CenaAutoMatycznychNozyczek}p)";
        LepszeNozyczkiText.text = $"Kup Nożyczki\n({CenaNozyczek}p)";
        LepszeAutoNozyczkiText.text = $"Kup Auto Nożyczki\n({CenaLepszychAutoNozyczek}p)";

        // Teksty opisow po prawej stronie.
        PointsElement.GetComponent<Text>().text = $"Punkty: {Points}p";
        LiczbaOwiecElement.GetComponent<Text>().text = $"Liczba owiec: {LiczbaOwiec}";
        AutoNozyczkiElement.GetComponent<Text>().text = $"Auto Nożyczki: +{AddPointsAutoNozyczki}p/{Przyspieszenie.ToString("n1")}s";
        LiczbaNozyczekElement.GetComponent<Text>().text = $"Liczba Nożyczek: {LiczbaNozyczek}";

        SaveGame.Save();
    }
}