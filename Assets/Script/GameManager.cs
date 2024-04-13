using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    // Propiedades (Campo)
    public static int round;                                         // (1) Número de Ronda
    public bool SkipRound;                                           // (2) True(si algún jugador pasa la ronda) 
    public GameObject[] numberRound;                                 // (3) Panel-Display hace referencia al número de ronda
    public GameObject panelGameOver;                                 // (4) Panel que muestra los resultados a final del juego
    public GameObject panelRound;                                    // (5) Panel que muestra los resultados a final de ronda
    DataBase dataCard;                                               // (6) Base de Datos de las cartas
    public  Player player1;                                          // (7) Jugador 1
    public  Player player2;                                          // (8) Jugador 2
    private Player start;                                            // (9) Jugador que comienza cada ronda
    private Player playerEnd;                                        // (10) Jugador que termina cada ronda
    static public Player currentPlayer;                              // (11) Jugador actual

    // Métodos
    private void CallPanelRound()                                    // Muestra el panel (5)
    {
        StartCoroutine(PanelRound());
        IEnumerator PanelRound()
        {
            panelRound.SetActive(true);
            Transform panel = panelRound.GetComponent<CanvasGroup>().transform;
            panel.GetChild(3).GetComponent<Image>().sprite = Winner(round).image;
            yield return new WaitForSeconds(3);

            panelRound.SetActive(false);
        }
    }                                   
    private void ButtonSkipTurn()                                    // Salta el turno
    {
        currentPlayer.oneMove = false;
        if (!SkipRound)
        {
            if (player1.myTurn)
            {
                player1.myTurn = false; player2.myTurn = true;
                currentPlayer = player2;
            }
            else
            {
                player2.myTurn = false; player1.myTurn = true;
                currentPlayer = player1;
            }
        }
        else
            ButtonSkipRound();
    }
    private void ButtonSkipRound()                                   // Tranformaciones cuando cambia de ronda
    {
        if (playerEnd == currentPlayer)
        {
            if (Winner() != null)
                PanelGameOver();
            else
            {
                CallPanelRound();
                SkipRound = false;
                currentPlayer.oneMove = false;
                if (player1.powerRound[round] > player2.powerRound[round])
                {
                    player1.myTurn = true; player2.myTurn = false;
                    currentPlayer = player1;
                    start = player1;
                    playerEnd = player2;
                }
                else
                {
                    player1.myTurn = false; player2.myTurn = true;
                    currentPlayer = player2;
                    start = player2;
                    playerEnd = player1;
                }
                round += 1;

                player1.Cementery();
                player2.Cementery();
                player1.TakeCard();
                player2.TakeCard();
            }
        }
        else
        {
            ButtonSkipTurn();
            SkipRound = true;
        }
    }
    private void PanelGameOver()                                     // Muestra el panel (4)
    {
        panelGameOver.SetActive(true);
        Transform panel = panelGameOver.GetComponent<CanvasGroup>().transform;

        //Player1
        panel.GetChild(6).GetComponent<Text>().text = player1.powerRound[0].ToString();
        panel.GetChild(7).GetComponent<Text>().text = player1.powerRound[1].ToString();
        panel.GetChild(8).GetComponent<Text>().text = player1.powerRound[2].ToString();

        //Player2
        panel.GetChild(9).GetComponent<Text>().text = player2.powerRound[0].ToString();
        panel.GetChild(10).GetComponent<Text>().text = player2.powerRound[1].ToString();
        panel.GetChild(11).GetComponent<Text>().text = player2.powerRound[2].ToString();

        //Winner
        if(Winner() != null)
        panel.GetChild(18).GetComponent<Image>().sprite = Winner().image;
    }
    private Player Winner(int round)                                 // Devuelve el ganador en una ronda (null si hay empate)
    {
        if (player1.GetComponent<Player>().powerRound[round] > player2.GetComponent<Player>().powerRound[round])
            return player1;

        else return player2;
    }
    private Player Winner()                                          // Método sobrecargado, devuelve el ganador hasta la ronda actual
    {
        // winner1-winner2 almacenan el número de rondas ganadas por jugador
        int winner1 = 0;
        int winner2 = 0;
        for (int i = 0; i < round + 1; i++)     
        {
            if (player1.powerRound[i] > player2.powerRound[i] && player1.powerRound[i] > player2.powerRound[i])
                winner1++;
            else if (player1.powerRound[i] < player2.powerRound[i] && player1.powerRound[i] < player2.powerRound[i])
                winner2++;
            else { winner1++; winner2++; }
        }
        if (winner1 == 2 || winner2 == 2)
        {
            if (winner1 > winner2)
                return player1;
            else return player2;
        }
        return null;
    }
    public void ButtonGoBack() => Invoke("GoBack", 0.2f);
    private void GoBack() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);  // Cambia de escena (menú principal)

    void Start()
    {
        dataCard = new DataBase();                                    // Crea una instancia de la base de datos
        dataCard.CreateCard();                                        // Crea las instancias de las cartas (crea los decks)
        round = 0;                                                    // Declara la ronda 1 (0)
    
        player1.deck = dataCard.deckDemon;                            // Asigna los decks a los jugadores
        player2.deck = dataCard.deckHeavenly;
        start = player1;                                              //  Declara el jugador que terminará la ronda
        playerEnd = player2;
        currentPlayer = player1;                                      // Declara el jugador que comienza la ronda 1
        player1.TakeCard();                                           // Agrega cartas a la mano
        player2.TakeCard();
    }
    void Update()
    {
        numberRound[round].GetComponent<CanvasGroup>().alpha = 1;     // Actualiza el panel (3) con la ronda ronda actual
    }
}
