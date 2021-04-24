using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuyNozyczkiScript : MonoBehaviour, IPointerClickHandler
{
    public GameObject EventSystem;
    public GameObject TextElement;

    public void OnPointerClick(PointerEventData eventData)
    {
        var punkty = EventSystem.GetComponent<GameScript>().BuyNozyczki();
        TextElement.GetComponent<Text>().text = $"Kup Lepsze Nożyczki\n({punkty}p)";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
