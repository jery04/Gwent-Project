using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepMusic : MonoBehaviour
{
    /* Este patr�n maneja la m�sica de fondo en el juego, donde solo una instancia 
     * de la m�sica de fondo est� reproduci�ndose en cualquier momento*/
    public static KeepMusic Instance;   // Singleton para asegurar que la clase tenga solo una instancia
    void Start()                        // Mantiene el objeto a trav�s de las escenas 1 y 2 (0)(1)
    {
        if (Instance == null)                                     
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()                       // Destruye el objeto en la tercera escena (2)
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
            GameObject.Destroy(gameObject);
    }
}
