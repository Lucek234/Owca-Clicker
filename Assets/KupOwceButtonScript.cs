using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KupOwceButtonScript : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        var nowaCena = EventSystem.GetComponent<GameScript>().BuySheep();
        TextElement.GetComponent<Text>().text = $"Kup Owcę\n({nowaCena} punkty)";
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
