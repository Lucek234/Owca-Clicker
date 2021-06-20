using Assets;

public class KurczakScript : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject EcoText;

    public GameObject EcoWybiegButtonText;
    public GameObject FloatingPointsAsset;
    public GameObject KurczakElement;
    public GameObject PunktyText;

    public int EcoLevel
    {
        get => SaveGame.EkoLevel;
        set => SaveGame.EkoLevel = value;
    }

    private SaveGame SaveGame { get; set; }
    public int CenaEko => 500 * (int) Mathf.Pow(2, EcoLevel);

    public int Points
    {
        get => SaveGame.Points;
        set => SaveGame.Points = value;
    }

    public int KurczakDeltaPoints => 5 * EcoLevel;

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


    // Update is called once per frame
    private void Update()
    {
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
        floating.GetComponent<RectTransform>().anchoredPosition =
            KurczakElement.GetComponent<RectTransform>().anchoredPosition + randPos;
    }

    public void OnKurczakClick()
    {
        var deltaPoints = KurczakDeltaPoints;
        Points += KurczakDeltaPoints;
        UpdatePoints();
        ShowAddPoints(deltaPoints, Color.white);
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
        SaveGame.Save();
    }
}