using Assets;
using UnityEngine;
using UnityEngine.UI;


public class KurczakScript : MonoBehaviour
{

    string AnimalName = "kurczak";
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

    private float timer => AutoPointsService.Instance.GetTimer("kurczak");
    public Text WiecejKurczakowButtonTekst;
    public Text WiecejKurczakowTekst;

    public int EcoLevel
    {
        get => SaveGame.EkoLevel;
        set => SaveGame.EkoLevel = value;
    }

    private SaveGame SaveGame => SaveGame.Instance;

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
    public int AutoPoints => 5 * EcoLevel * LiczbaKurczokow;

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

    private float AutoTime => 9.5f / (1 + PoziomLepszejPaszy) + 0.5f;

    public int LiczbaLepszejPaszy { get=> SaveGame.KurczokLiczbaLepszejPaszy; set=>SaveGame.KurczokLiczbaLepszejPaszy=value; }

    private void Start()
    {
        vacuum =        GameObject.Find("Vacuum").GetComponent<VacuumScript>();
        //Points += 100000000;
        UpdatePoints();
    }

    // Update is called once per frame
    private void Update()
    {
        if (timer > AutoTime && AutoZbieraczeJaj > 0)
        {
            //timer = 0;
            WezwijZbieraczaJaj();
        }

        var autoPoints = AutoPointsService.Instance.GetAutoPoints();
        Debug.Log($"Autopoints: {autoPoints}");
        AutoPointsUpdate(autoPoints);
        //timer += Time.deltaTime;
        UpdatePoints();
        AutoPointsService.Instance.Update(Time.deltaTime);
    }


    public void AutoPointsUpdate(int points)
    {
        if (points == 0) return;
        Points += points;
        ShowAddPoints(points, new Color(255, 0, 255));
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
        SaveGame.Save();
    }


    public void OnKurczakClick()
    {
        Points += AutoPoints;
        UpdatePoints();
        ShowAddPoints(AutoPoints, Color.white);
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
        AutoJajaText.text = $"Auto jaja {AutoZbieraczeJaj}p/{AutoTime:n1}s";
        SaveGame.Save();
        vacuum.TimeA = AutoTime / 4;
        vacuum.TimeB = AutoTime / 4;
        vacuum.TimeC = AutoTime / 2;


        AutoPointsService.Instance.UpdateAnimal(AnimalName, AutoPoints, AutoTime);
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