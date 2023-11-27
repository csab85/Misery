using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Violence : MonoBehaviour
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

    /// <summary>
    /// Switches the current profile pic and actor name mid dialogue
    /// </summary>
    /// <param name="name">The new name</param>
    /// <param name="portrait">The new profile pic</param>
    /// <param name="funcProfileSize">The new profile pic scale</param>
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

                    speech = new string[] { "E a�, novato, t� de boa?" };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 1.1f;

                    break;

                case 1.1f:

                    speech = new string[] { "Sim." };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 1.2f;

                    SwitchActor("Mis�ria", portraits[0]);

                    break;

                case 1.2f:

                    speech = new string[] { "J� se acostumou com o trabalho por aqui?" };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 1.3f;

                    SwitchActor("Viol�ncia", portraits[1]);

                    break;

                case 1.3f:

                    speech = new string[] { "Sim." };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 1.4f;

                    SwitchActor("Mis�ria", portraits[0]);

                    break;

                case 1.4f:

                    speech = new string[] { "Gostou do pessoal?" };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 1.5f;

                    SwitchActor("Viol�ncia", portraits[1]);

                    break;

                case 1.5f:

                    speech = new string[] { "Sim." };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 1.6f;

                    SwitchActor("Mis�ria", portraits[0]);

                    break;

                case 1.6f:

                    speech = new string[] { "VOC� N�O SABE RESPONDER QUALQUER OUTRA COISA???" };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 1.7f;
                    GetComponent<Animator>().SetBool("raging", true);

                    SwitchActor("VIOL�NCIA", portraits[2], 1.83f);

                    break;

                case 1.7f:

                    speech = new string[] { "..." };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 1.8f;

                    SwitchActor("Mis�ria", portraits[0]);

                    break;

                case 1.8f:

                    speech = new string[] { ".......", "Foi mal.", "Eu explodo f�cil.", "De qualquer jeito...", "Eu sou a pessoa mais legal por aqui!", "Quer dizer, eu pego fogo.", "� irado n�?", "Isso t�, de alguma forma, ligado ao meu leve descontrolamento." };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 1.9f;
                    GetComponent<Animator>().SetBool("raging", false);

                    SwitchActor("Viol�ncia", portraits[1]);

                    break;

                case 1.9f:

                    speech = new string[] { "Nem imaginei..." };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 1.91f;

                    SwitchActor("Mis�ria", portraits[0]);

                    break;

                case 1.91f:

                    speech = new string[] { "VOC� EST� SENDO IR�NICO COMIGO, SEU PINGO CINZA E IRRITANTE?" };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 1.92f;
                    GetComponent<Animator>().SetBool("raging", true);

                    SwitchActor("VIOL�NCIA", portraits[2], 1.83f);

                    break;

                case 1.92f:

                    speech = new string[] { "N�o..." };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 1.93f;

                    SwitchActor("Mis�ria", portraits[0]);

                    break;

                case 1.93f:

                    speech = new string[] { "Ok, n�o sei se gosto de voc�." };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 1;
                    GetComponent<Animator>().SetBool("raging", false);

                    SwitchActor("Viol�ncia", portraits[1]);

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
