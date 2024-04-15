using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chose : MonoBehaviour
{
    public Button[] button;
    public Button butStart; 
    DataBase data;
    public InputField input1, input2;
    public static List<Card> deck1, deck2;
    public static string name1, name2;
    public void ActionEvent(string nameMethod)     // Llama a la próxima escena
    {
        Invoke(nameMethod, 0.2f);
    }
    private void GoPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ButtonStark(bool key)
    {
        if(key && input1.text != "Nombre" && input1.text != "")
        {
            name1 = input1.text;
            deck1 = data.deckStark;
            button[1].GetComponent<Button>().interactable = false;
            button[2].GetComponent<Button>().interactable = false;
        }
        else if (input2.text != "Nombre" && input2.text != "")
        {
            name2 = input2.text;
            deck2 = data.deckStark;
            button[4].GetComponent<Button>().interactable = false;
            button[5].GetComponent<Button>().interactable = false;
        }

    }
    public void ButtonTargaryen(bool key)
    {
        if (key && input1.text != "Nombre" && input1.text != "")
        {
            name1 = input1.text;
            deck1 = data.deckTargaryen;
            button[0].GetComponent<Button>().interactable = false;
            button[2].GetComponent<Button>().interactable = false;
        }
        else if (input2.text != "Nombre" && input2.text != "")
        {
            name2 = input2.text;
            deck2 = data.deckTargaryen;
            button[3].GetComponent<Button>().interactable = false;
            button[5].GetComponent<Button>().interactable = false;
        }

    }
    public void ButtonDead(bool key)
    {
        if (key && input1.text != "Nombre" && input1.text != "")
        {
            name1 = input1.text;
            deck1 = data.deckDead;
            button[0].GetComponent<Button>().interactable = false;
            button[1].GetComponent<Button>().interactable = false;
        }
        else if (input2.text != "Nombre" && input2.text != "")
        {
            name2 = input2.text;
            deck2 = data.deckDead;
            button[3].GetComponent<Button>().interactable = false;
            button[4].GetComponent<Button>().interactable = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        data = new DataBase();
        data.CreateCard();
    }

    // Update is called once per frame
    void Update()
    {
        if(deck1 != null && deck2 != null)
        {
            butStart.GetComponent<Button>().interactable = true;
        }
    }
}
