using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject musicManager;
    public Button musicButton;
    public Sprite play;
    public Sprite stop;
    bool sound = true;
    public void ActiveSound()
    {
        if (sound)
        {
            musicButton.GetComponent<Image>().sprite = play;
            musicManager.GetComponent<AudioSource>().Stop();
            sound = false;
        }

        else
        {
            musicButton.GetComponent<Image>().sprite = stop;
            musicManager.GetComponent<AudioSource>().Play();
            sound = true;
        }

    }
    public void ActionEvent(string nameMethod)     // Llama a la próxima escena
    {
        Invoke(nameMethod, 0.2f);
    }
    private void GoPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void Out()                            // Cierra la aplicación
    {
        Application.Quit();
    }
}
