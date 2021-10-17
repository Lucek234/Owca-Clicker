using Assets;
using UnityEngine;
using UnityEngine.UI;


public class KurczakScript : MonoBehaviour
{
    public Text AutoJajaText;
    public Text AutoZbieraczButtonText;
    public GameObject Canvas;
    public GameObject EcoText;

    public GameObject EcoWybiegButtonText;
    public GameObject FloatingPointsAsset;
    public GameObject JajoAsset;
    public GameObject KurczakElement;
    public Text LepszaPaszaButtonText;
    public GameObject PunktyText;

    private float timer;
    public Text WiecejKurczakowButtonTekst;
    public Text WiecejKurczakowTekst;

    public int EcoLevel
    {
        get => SaveGame.EkoLevel;
        set => SaveGame.EkoLevel = value;
    }

    private SaveGame SaveGame { get; set; } = new SaveGame();

    /// <summary>
    /// Przycisk 3 - liczba autozbieraczy jaj. Definiuje jak czesto pojawia sie jajo i jest zgarniane przez odkurzacz.
    /// </summary>
    public int AutoZbieraczeJaj
    {
        get => SaveGame.KurczakAutoZbieraczJaj;
        set => SaveGame.KurczakAutoZbieraczJaj = value;
    }

    public int CenaAutoZbieraczJaj => 3000 * (int) Mathf.Pow(3, AutoZbieraczeJaj);

    public int CenaEko => 1000 * (int) Mathf.Pow(2, EcoLevel);
    public int CenaKurczoka => 1000 * (int) Mathf.Pow(4, LiczbaKurczokow);
    public int KurczakDeltaPoints => 5 * EcoLevel * LiczbaKurczokow;

    public int CenaLepszejPaszy => 5000 * (int) Mathf.Pow(5,PoziomLepszejPaszy);

    public int PoziomLepszejPaszy
    {
        get => SaveGame.KurczakLepszaPaszaLevel;
        set => SaveGame.KurczakLepszaPaszaLevel = value;
    }

    public int LiczbaKurczokow
    {
        get => SaveGame.LiczbaKurczokow;
        set => SaveGame.LiczbaKurczokow = value;
    }

    public int Points
    {
        get => SaveGame.Points;
        set => SaveGame.Points = value;
    }

    VacuumScript vacuum;
    public int AddJajoPunkty()
    {
        var points = AutoZbieraczeJaj;
        Points += points;
        return points;
    }

    private float OkresCzasu => 9.5f / (1 + PoziomLepszejPaszy) + 0.5f;

    public int LiczbaLepszejPaszy { get=> SaveGame.KurczokLiczbaLepszejPaszy; set=>SaveGame.KurczokLiczbaLepszejPaszy=value; }

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

        vacuum =        GameObject.Find("Vacuum").GetComponent<VacuumScript>();
        //Points += 100000000;
        UpdatePoints();
    }

    // Update is called once per frame
    private void Update()
    {
        if (timer > OkresCzasu && AutoZbieraczeJaj > 0)
        {
            timer = 0;
            WezwijZbieraczaJaj();
        }

        timer += Time.deltaTime;
        UpdatePoints();
    }

    public void WezwijZbieraczaJaj()
    {
        var jajo = Instantiate(JajoAsset, Canvas.transform);
    }


    public void ShowAddPoints(int addPoints, Color color, int fontSize = 30)
    {
        var floating = Instantiate(FloatingPointsAsset, Canvas.transform);
        var textComp = floating.GetComponent<Text>();
        textComp.text = $"+{addPoints}p";
        textComp.color = color;
        textComp.fontSize = fontSize;
        var dx = Random.Range(-100, 100);
        var dy = Random.Range(-50, 100);
        var randPos = new Vector2(dx, dy);
        floating.GetComponent<RectTransform>().anchoredPosition =
            KurczakElement.GetComponent<RectTransform>().anchoredPosition + randPos;

    }


    public void OnKurczakClick()
    {
        Points += KurczakDeltaPoints;
        UpdatePoints();
        ShowAddPoints(KurczakDeltaPoints, Color.white);
    }

    public void OnEcoWybiegButtonClick()
    {
        if (Points < CenaEko|| LiczbaKurczokow == 0) return;
        Points -= CenaEko;
        EcoLevel += 1;
        UpdatePoints();
    }

    public void UpdatePoints()
    {
        PunktyText.GetComponent<Text>().text = $"Punkty: {Points}p";
        EcoText.GetComponent<Text>().text = $"Poziom eko: {EcoLevel}";
        EcoWybiegButtonText.GetComponent<Text>().text = $"Rozwoj eko:\n{CenaEko}";
        WiecejKurczakowButtonTekst.text = $"Kup kurczaka\n({CenaKurczoka})";
        WiecejKurczakowTekst.text = $"Liczba kurczaków: {LiczbaKurczokow}";
        AutoZbieraczButtonText.text = $"Zatrudnij zbieracza jaj\n{CenaAutoZbieraczJaj}";
        LepszaPaszaButtonText.text = $"Kup lepszą paszę\n{CenaLepszejPaszy}";
        AutoJajaText.text = $"Auto jaja {AutoZbieraczeJaj}p/{OkresCzasu:n1}s";
        SaveGame.Save();
        vacuum.TimeA = OkresCzasu / 4;
        vacuum.TimeB = OkresCzasu / 4;
        vacuum.TimeC = OkresCzasu / 2;
    }


    public void ZatrudnijAutoZbieraczaJaj()
    {
        if (Points < CenaAutoZbieraczJaj || LiczbaKurczokow ==0) return;
        Points -= CenaAutoZbieraczJaj;
        AutoZbieraczeJaj += 1;
    }

    public void KupKurczoka()
    {
        if (Points < CenaKurczoka) return;
        Points -= CenaKurczoka;
        LiczbaKurczokow += 1;
    }

    public void OnLepszaPaszaButtonClick()
    {
        if (Points < CenaLepszejPaszy || LiczbaKurczokow == 0) return;
        Points -= CenaLepszejPaszy;
        PoziomLepszejPaszy += 1;
    }
}