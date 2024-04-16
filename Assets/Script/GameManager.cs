using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    // Propiedades (Campo)
    public static int round;                                         // (1) N�mero de Ronda
    public bool SkipRound;                                           // (2) True(si alg�n jugador pasa la ronda) 
    public GameObject[] numberRound;                                 // (3) Panel-Display hace referencia al n�mero de ronda
    public GameObject panelGameOver;                                 // (4) Panel que muestra los resultados a final del juego
    public GameObject panelRound;                                    // (5) Panel que muestra los resultados a final de ronda
    public  Player player1;                                          // (7) Jugador 1
    public  Player player2;                                          // (8) Jugador 2
    private Player start;                                            // (9) Jugador que comienza cada ronda
    private Player playerEnd;                                        // (10) Jugador que termina cada ronda
    static public Player currentPlayer;                              // (11) Jugador actual

    // M�todos
    private void CallPanelRound()                                    // Muestra el panel (5)
    {
        StartCoroutine(PanelRound());
        IEnumerator PanelRound()
        {
            panelRound.SetActive(true);
            Transform panel = panelRound.GetComponent<CanvasGroup>().transform;

            if (Winner(round) != null)
                panel.GetChild(3).GetComponent<Text>().text = Winner(round).playerName;
            else 
                panel.GetChild(3).GetComponent<Text>().text = "DRAW";

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
                    currentPlayer = player1; start = player1; playerEnd = player2;
                }
                else
                {
                    player1.myTurn = false; player2.myTurn = true;
                    currentPlayer = player2; start = player2; playerEnd = player1;
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

        //Name Players
        panel.GetChild(17).GetComponent<Text>().text = player1.playerName;
        panel.GetChild(18).GetComponent<Text>().text = player2.playerName;

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
        panel.GetChild(15).GetComponent<Text>().text = Winner().playerName;
    }
    private Player Winner(int round)                                 // Devuelve el ganador en una ronda (null si hay empate)
    {
        if (player1.GetComponent<Player>().powerRound[round] > player2.GetComponent<Player>().powerRound[round])
            return player1;

        else return player2;
    }
    private Player Winner()                                          // M�todo sobrecargado, devuelve el ganador hasta la ronda actual
    {
        // winner1-winner2 almacenan el n�mero de rondas ganadas por jugador
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
    public void ButtonGoBack() => Invoke("GoBack", 0.2f);            // Volver al Men� Principal
    private void GoBack() => SceneManager.LoadScene(0);              // Cambia de escena (men� principal)
    public void Yes() => currentPlayer.ButtonTrigger(true);          // Bot�n(Yes) tomar cartas antes de la batalla
    public void Not() => currentPlayer.ButtonNot();                  // Bot�n(No) tomar cartas antes de la batalla

    void Start()                                                     // Inicializaci�n de propiedades
    {
        round = 0;                                                    // Declara el inicio de ronda 1 (0)

        player1.deck = Chose.deck1;                                   // Asigna los decks a los jugadores
        player2.deck = Chose.deck2;
        player1.playerName = Chose.name1;                             // Asigna los nombres a los jugadores
        player2.playerName = Chose.name2;

        start = player1;                                              //  Declara el jugador que empieza la ronda
        playerEnd = player2;                                          //  Declara el jugador que termina la ronda
        currentPlayer = player1;                                      // Declara el jugador que comienza la ronda 1

        player1.TakeCard();                                           // Agrega cartas a la mano de los jugadores
        player2.TakeCard();
    }
    void Update()
    {
        numberRound[round].GetComponent<CanvasGroup>().alpha = 1;    // Actualiza el panel (3) con la ronda actual
    }
}
