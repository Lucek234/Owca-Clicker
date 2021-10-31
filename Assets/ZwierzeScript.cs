
using UnityEngine;
using UnityEngine.UI;
using Assets;
public abstract class ZwierzeScript : MonoBehaviour
{

    public GameObject Canvas;
    public Text Button1Label;
    public Text Label1;
    public Text Button2Label;
    public Text Label2;
    public Text Button3Label;
    public Text Label3;
    public Text Button4Label;
    public Text Label4;

    public GameObject Zwierze;
    public GameObject FloatingPointsAsset;

    public int Points
    {
        get => SaveGame.Points;
        set => SaveGame.Points = value;
    }

    public SaveGame SaveGame => SaveGame.Instance;
    public virtual string Button1LabelText { get; }
    public virtual string Button2LabelText { get; }
    public virtual string Button3LabelText { get; }
    public virtual string Button4LabelText { get; }

    public virtual string Label1Text { get; }
    public virtual string Label2Text { get; }
    public virtual string Label3Text { get; }
    public virtual string Label4Text { get; }
    public virtual int Button1Cost { get; }
    public virtual int Button2Cost { get; }
    public virtual int Button3Cost { get; }
    public virtual int Button4Cost { get; }
    public virtual int Button1Level { get; set; }
    public virtual int Button2Level { get; set; }
    public virtual int Button3Level { get; set; }
    public virtual int Button4Level { get; set; }
    public virtual int ZwierzeDeltaPoints { get; }

    public virtual int AutoPoints { get; } = 10;
    public virtual float AutoTime { get; } = 10;

    public void Start()
    {

    }
    float timer = 0;
    public void Update()
    {
        var autoPoints = AutoPointsService.Instance.GetAutoPoints();
        if (autoPoints > 0)
        {

        }
        PointsUpdate();
        AutoPointsService.Update(Time.deltaTime);
    }

    public virtual void AutoPointsUpdate(int points)
    {
        if (points == 0) return;
        Points += points;
        ShowAddPoints(points, new Color(255, 0, 255));
    }

    public string AnimalName;

    public void PointsUpdate()
    {
        Button1Update();
        Button2Update();
        Button3Update();
        Button4Update();
        Label1Update();
        Label2Update();
        Label3Update();
        Label4Update();

        AutoPointsService.UpdateAnimal(AnimalName, AutoPoints, AutoTime);
    }


 public   AutoPointsService AutoPointsService => AutoPointsService.Instance;

    public void Button1Update() {    
        Button1Label.text = Button1LabelText;
    }
    public void Button2Update()
    {
        Button2Label.text = Button2LabelText;
    }
    public void Button3Update()
    {
        Button3Label.text = Button3LabelText;
    }
    public void Button4Update() {
        Button4Label.text = Button4LabelText;
    }
    public virtual void Label1Update() {
        Label1.text = Label1Text;
    }
    public virtual void Label2Update() {
        Label2.text = Label2Text;
    }
    public virtual void Label3Update()
    {
        Label3.text = Label3Text;
    }
    public virtual void Label4Update()
    {
        Label4.text = Label4Text;
    }

    void Save()
    {
        SaveGame.Save();
    }
    public void Button1()
    {
        if (Points < Button1Cost) return;
        Points -= Button1Cost;
        Button1Level += 1;
        Save();
    }

    public void Button2()
    {

        if (Points < Button2Cost) return;
        Points -= Button2Cost;
        Button2Level += 1;
        Save();
    }

    public void Button3()
    {

        if (Points < Button3Cost) return;
        Points -= Button3Cost;
        Button3Level += 1;
        Save();
    }

    public void Button4()
    {
        if (Points < Button4Cost) return;
        Points -= Button4Cost;
        Button4Level += 1;
        Save();
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
            Zwierze.GetComponent<RectTransform>().anchoredPosition + randPos;

    }

    public int BazowePunkty = 25;

    public void OnZwierzeClick()
    {
        Points += ZwierzeDeltaPoints;
        PointsUpdate();
        ShowAddPoints(ZwierzeDeltaPoints, Color.white);
        Save();
    }

}