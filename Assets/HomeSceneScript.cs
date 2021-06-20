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
        SceneManager.LoadScene("OwcaScreen", LoadSceneMode.Single);
    }

    public void GoOwca()
    {

        SceneManager.LoadScene("OwcaScreen", LoadSceneMode.Single);
    }

    public void GoKurczak()
    {

        SceneManager.LoadScene("KurczakScreen", LoadSceneMode.Single);
    }

    public void GoKrowa()
    {
        SceneManager.LoadScene("OwcaScreen", LoadSceneMode.Single);
    }

    public void GoKoza()
    {
        SceneManager.LoadScene("OwcaScreen", LoadSceneMode.Single);
    }
}
