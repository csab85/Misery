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
                speech = new string[] { "E a�, novato, t� de boa?", "J� se acostumou com o trabalho por aqui?", "Gostou dos seus colegas de trabalho?", "...", ".........", "..........................................", "N�O VAI RESPONDER N�O �?!", "Perco a paci�ncia r�pido, perd�o.", "Eu sou a pessoa mais legal por aqui.", "Quer dizer...", "Eu pego FOGO!", "� irado n�?", "Isso est�, atrelado ao meu leve descontrolamento.", "......", "Que foi?", "Eu to vendo esse sorrisinho.", "Voc� t� rindo do que?", ".........", "VOC� T� RINDO DE MIM, SEU PINGO DE HUMANO CINZA E IRRITANTE?!?", "......", "Ok, n�o sei se gosto de voc�.", " Mas ainda assim, sinto que devo te dar um pequeno conselho.", "Para um pequeno amigo.", "Sabe?", "N�o confia naquela Paz n�o.", "Ela fede!", "E seu nome?", "Pura piada por aqui.", "Cuidado pra n�o virar piada tamb�m, pequenino.", "Tchau tchau.", "Hihihi, Pequeno conselho para um pequeno amigo...", "Eu sou hil�ria!" };

                nextProgressionValue = 4;

                break;
        }

        dialogue.speechTxt = speech;
        dialogue.nextProgressionValue = nextProgressionValue;
    }

    #endregion
    //========================


}
