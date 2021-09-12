using System.Collections;
using Assets;
using UnityEngine;
using UnityEngine.UI;

public class KurczakScript : MonoBehaviour
{
    public Text AutoZbieraczButtonText;
    public GameObject Canvas;
    public GameObject EcoText;

    public GameObject EcoWybiegButtonText;
    public GameObject FloatingPointsAsset;
    public GameObject KurczakElement;
    public GameObject PunktyText;
    public Text WiecejKurczakowButtonTekst;
    public Text LepszaPaszaButtonText;
    public Text WiecejKurczakowTekst;
    public Text AutoJajaText;
    public int EcoLevel
    {
        get => SaveGame.EkoLevel;
        set => SaveGame.EkoLevel = value;
    }

    private SaveGame SaveGame { get; set; }

    public int AutoZbieraczeJaj
    {
        get => SaveGame.KurczakAutoZbieraczJaj;
        set => SaveGame.KurczakAutoZbieraczJaj = value;
    }

    public int CenaAutoZbieraczJaj => 3000 * (int) Mathf.Pow(3, AutoZbieraczeJaj);

    public int CenaEko => 1000 * (int) Mathf.Pow(2, EcoLevel);
    public int CenaKurczoka => 1000 * (int) Mathf.Pow(4, LiczbaKurczokow);
    public int KurczakDeltaPoints => 5 * EcoLevel * LiczbaKurczokow;

    public int CenaLepszejPaszy => 5000 * PoziomLepszejPaszy;
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


    public int LiczbaOkresu
    {
        get => SaveGame.KurczokLiczbaPrzyspieszenia;
        set => SaveGame.KurczokLiczbaPrzyspieszenia = value;
    }

    private float OkresCzasu => 9.5f / (1 + LiczbaOkresu) + 0.5f;

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

    private float timer = 0;

    // Update is called once per frame
    private void Update()
    {
        if (timer > OkresCzasu)
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
    public GameObject JajoAsset;kts(int addPoints, Color color, int fontSize = 30)
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
        if (Points < CenaEko) return;
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
    }


    public void ZatrudnijAutoZbieraczaJaj()
    {
        if (Points < CenaAutoZbieraczJaj) return;
        Points -= CenaAutoZbieraczJaj;
        AutoZbieraczeJaj += 1;
    }

    public void KupKurczoka()
    {
        if (Points < CenaKurczoka) return;
        Points -= CenaKurczoka;
        LiczbaKurczokow += 1;
    }


}