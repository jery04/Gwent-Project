using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject musicManager;               // Objeto que almacena la musica de fondo y el sonido de los botones
    public Button buttonMute;                     // Bot�n para silenciar la m�sica de fondo 
    public Sprite playMusicIcon;                  // Imagen de boton Play         
    public Sprite stopMusicIcon;                  // Imagen de boton Stop  
    bool sound = true;                            // Estado(Active) del sonido de fondo
    public void ActiveSound()                     // Modifica el estado(Active) del sonido de fondo
    {
        if (sound)                                // Si est� sonando lo pausa                                
        {
            buttonMute.GetComponent<Image>().sprite = playMusicIcon;
            musicManager.GetComponent<AudioSource>().Stop();
            sound = false;
        }
        else                                       // Si est� pausado lo reproduce                                       
        {
            buttonMute.GetComponent<Image>().sprite = stopMusicIcon;
            musicManager.GetComponent<AudioSource>().Play();
            sound = true;
        }

    }
    public void ActionEvent(string nameMethod)    // Llama a la pr�xima escena
    {
        Invoke(nameMethod, 0.2f);
    }
    private void GoPlay()                         // Llama a la pr�xima escena
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void CreateCard()
    {
        SceneManager.LoadScene("CreateCard");
    }
    private void Out()                            // Cierra la aplicaci�n
    {
        Application.Quit();
    }
}                                                 
