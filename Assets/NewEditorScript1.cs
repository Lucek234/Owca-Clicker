
using UnityEngine;
using UnityEngine.UI;

public class ZwierzeScript : MonoBehaviour
{

    public Text Button1Label1;
    public Text Label1;
    public Text Button1Label2;
    public Text Label2;
    public Text Button1Label3;
    public Text Label3;
    public Text Button1Label4;
    public Text Label4;

    public int Button1Cost { get; set; }
    public int Button2Cost { get; set; }
    public int Button3Cost { get; set; }
    public int Button4Cost { get; set; }
    public int ButtonLevel1 { get; set; }
    public int ButtonLevel2 { get; set; }
    public int ButtonLevel3 { get; set; }
    public int ButtonLevel4 { get; set; }
    public int Points { get; set; }
    public void Start()
    {

    }

    public void Update()
    {
        PointsUpdate();
    }

    public void PointsUpdate()
    {

    }

    public void Button1()
    {
        if (Points < Button1Cost) return;
        Points -= Button1Cost;
        ButtonLevel1 += 1;
    }

    public void Button2()
    {

        if (Points < Button2Cost) return;
        Points -= Button2Cost;
        ButtonLevel2 += 1;
    }

    public void Button3()
    {

        if (Points < Button3Cost) return;
        Points -= Button3Cost;
        ButtonLevel3 += 1;
    }

    public void Button4()
    {

        if (Points < Button4Cost) return;
        Points -= Button4Cost;
        ButtonLevel4 += 1;
    }
}