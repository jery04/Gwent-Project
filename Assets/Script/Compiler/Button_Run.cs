using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Run : MonoBehaviour
{
    public GameObject Errors_Panel;
    public GameObject InfErrors_Button;
    public GameObject Error_Warns;

    public void Run()
    {
        ResetEverything();
        Warn_Active(false);

        string[] code = LineNumberDisplay.code;
        IScope scope = new Scope();
        Lexer lexer = new Lexer(code);
        Parser parser = new Parser(lexer.GetLexer());
        ProgramCompiler program = parser.Parse();

        if (code.Length == 1 && code[0] == "")
        {
            Utils.errors.Add("No se ha escrito ninguna sentencia de c�digo");
            Warn_Active(true);
        }
        else if (Utils.NotError)
        {
            if (program.CheckSemantic(scope))
                DataBase.CreateCardsCompiler(program);

            else
                Warn_Active(true);
        }
        else
            Warn_Active(true);
    }
    private void ResetEverything()
    {
        Utils.Reset();
        Errors_Panel.transform.GetChild(1).GetComponent<Text>().text = "";
    }
    private void Warn_Active(bool active)
    {
        InfErrors_Button.SetActive(active);
        Error_Warns.SetActive(active);

        if (active)
            for (int i = 0; i < Utils.errors.Count; i++)
                Errors_Panel.transform.GetChild(1).GetComponent<Text>().text += $"{i + 1}) " + Utils.errors[i] + "\n";
    }
    public void Button_ErrorsWarn()
    {
        Errors_Panel.SetActive(true);
    }
    public void Button_BackCompiler()
    {
        Errors_Panel.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
