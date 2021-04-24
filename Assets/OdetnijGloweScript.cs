using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class OdetnijGloweScript : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var n = EventSystem.GetComponent<GameScript>().KupNozyczki();
        TextElement.GetComponent<Text>().text = $"Kup Auto Matyczne Nożyczki\n({n} punktów)";
    }

    public GameObject EventSystem;
    public GameObject TextElement;
}
