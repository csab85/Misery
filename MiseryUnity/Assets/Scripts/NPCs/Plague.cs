using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plague : MonoBehaviour
{
    //IMPORTS
    //========================
    #region

    public Misery miseryScript;
    public DialogueNPC dialogue;
    [SerializeField] Sprite[] portraits;

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

    void SwitchActor(string name, Sprite portrait, float funcProfileSize = 1)
    {
        dialogue.actorName = name;

        dialogue.profileSprite = portrait;

        dialogue.Talk(funcProfileSize);
    }

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
        if (dialogue.onRadius)
        {
            switch (miseryScript.progression)
            {
                case 1:

                    speech = new string[] { "E a�,?! Eu sou a Peste!", "E esse aqui do meu lado tamb�m � a Peste.", "Ele n�o � um cara muito agrad�vel...", "Mas a gente tem que conviver n�?" };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 1.1f;

                    break;

                case 1.1f:

                    speech = new string[] { "Cala a boca.", "Ele que � dif�cil de se conviver.", "J� imaginou algu�m falante e feliz o tempo todo?", "� insuport�vel!" };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 1.2f;

                    SwitchActor("Peste Triste", portraits[2], 1.8f);

                    break;

                case 1.2f:

                    speech = new string[] { "..." };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 1.3f;

                    SwitchActor("Mis�ria", portraits[0]);

                    break;

                case 1.3f:

                    speech = new string[] { "�, ele � dos meus." };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 1.4f;

                    SwitchActor("Peste Triste", portraits[2], 1.8f);

                    break;

                case 1.4f:

                    speech = new string[] { "Afe, chega de gente chata por aqui." };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 1;

                    SwitchActor("Peste Feliz", portraits[1], 1.93f);

                    break;

                default:

                    speech = new string[] { "..." };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = miseryScript.progression;

                    break;
            }

            dialogue.nextProgressionValue = nextProgressionValue;
        }
    }

    #endregion
    //========================


}
