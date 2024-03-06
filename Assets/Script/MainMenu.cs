using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayScene()     // Llama a la pr�xima escena
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Out()   // Cierra la aplicaci�n
    {
        Application.Quit();
    }
}
