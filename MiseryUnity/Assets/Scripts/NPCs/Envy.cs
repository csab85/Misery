using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Envy : MonoBehaviour
{
    //IMPORTS
    //========================
    #region

    public Misery miseryScript;
    public DialogueNPC dialogue;

    #endregion
    //========================


    //STATS AND VALUES
    //========================
    #region

    string[] speech;
    float nextProgressionValue;

    #endregion
    //========================


    //FUNCTIONS
    //========================
    #region



    #endregion
    //========================


    //RUNNING
    //========================
    #region

    //Start
    void Start()
    {

    }

    //Update
    void Update()
    {
        switch (miseryScript.progression)
        {
            case 4:
                speech = new string[] { "Que bom te ver por aqui, estava ansiosa para te conhecer.", "Sou a Inveja, meu caro!", "Sabe, eu gostaria de ter o seu emprego, parece melhor que o meu...", "Paga melhor que o meu também?", "......", "Não quer falar, claro!", "Isso não me daria inveja, é só um nome bobo atrelado a mim.", "Bem que eu queria ter sido escolhido pelo chefe...", "Bastardo sortudo!" };

                nextProgressionValue = 4;

                break;
        }

        dialogue.speechTxt = speech;
        dialogue.nextProgressionValue = nextProgressionValue;
    }

    #endregion
    //========================


}
