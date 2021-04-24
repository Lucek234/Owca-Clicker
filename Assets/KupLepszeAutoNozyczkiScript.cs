using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KupLepszeAutoNozyczkiScript : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        var nowaCena = EventSystem.GetComponent<GameScript>().BuyLepszeAutoNozyczki();
        TextElement.GetComponent<Text>().text = $"Kup lepsze auto nożyczki\n({nowaCena} punkty)";
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject EventSystem;
    public GameObject TextElement;
}
