using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prejudice : MonoBehaviour
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
                speech = new string[] { "A�, quem �?", "Ah, o cara novo, Mis�ria n�?", "N�o � muito falador, percebo.", "Disseram-me que voc� � um tanto sem cor e pequeno.", "Voc� � estranho por aqui.", "N�o gosto de estranhos.", "Nem de novidades.", "VAI EMBORA!!" };

                nextProgressionValue = 4;

                break;
        }

        dialogue.speechTxt = speech;
        dialogue.nextProgressionValue = nextProgressionValue;
    }

    #endregion
    //========================


}
