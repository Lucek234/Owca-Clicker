using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeSceneScript : MonoBehaviour
{
    public static string LastScene { get; set; }
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void GoBack()
    {
        SceneManager.LoadScene(LastScene ?? "OwcaScreen", LoadSceneMode.Single); 
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
        SceneManager.LoadScene("KrowaScreen", LoadSceneMode.Single);
    }

    public void GoKoza()
    {
        SceneManager.LoadScene("KozaScreen", LoadSceneMode.Single);
    }
}