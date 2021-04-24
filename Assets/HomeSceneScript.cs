using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoBack()
    {
        SceneManager.LoadScene("OwcaScreen", LoadSceneMode.Additive);
    }

    public void GoOwca()
    {

        SceneManager.LoadScene("OwcaScreen", LoadSceneMode.Additive);
    }

    public void GoKurczak()
    {

        SceneManager.LoadScene("OwcaScreen", LoadSceneMode.Additive);
    }

    public void GoKrowa()
    {
        SceneManager.LoadScene("OwcaScreen", LoadSceneMode.Additive);
    }

    public void GoKoza()
    {
        SceneManager.LoadScene("OwcaScreen", LoadSceneMode.Additive);
    }
}
