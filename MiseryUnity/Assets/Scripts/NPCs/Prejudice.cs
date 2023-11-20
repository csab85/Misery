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
                speech = new string[] { "Aí, quem é?", "Ah, o cara novo, Miséria né?", "Não é muito falador, percebo.", "Disseram-me que você é um tanto sem cor e pequeno.", "Você é estranho por aqui.", "Não gosto de estranhos.", "Nem de novidades.", "VAI EMBORA!!" };

                nextProgressionValue = 4;

                break;
        }

        dialogue.speechTxt = speech;
        dialogue.nextProgressionValue = nextProgressionValue;
    }

    #endregion
    //========================


}
