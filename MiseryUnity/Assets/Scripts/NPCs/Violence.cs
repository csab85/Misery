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
                speech = new string[] { "E aí, novato, tá de boa?", "Já se acostumou com o trabalho por aqui?", "Gostou dos seus colegas de trabalho?", "...", ".........", "..........................................", "NÃO VAI RESPONDER NÃO Ô?!", "Perco a paciência rápido, perdão.", "Eu sou a pessoa mais legal por aqui.", "Quer dizer...", "Eu pego FOGO!", "É irado né?", "Isso está, atrelado ao meu leve descontrolamento.", "......", "Que foi?", "Eu to vendo esse sorrisinho.", "Você tá rindo do que?", ".........", "VOCÊ TÁ RINDO DE MIM, SEU PINGO DE HUMANO CINZA E IRRITANTE?!?", "......", "Ok, não sei se gosto de você.", " Mas ainda assim, sinto que devo te dar um pequeno conselho.", "Para um pequeno amigo.", "Sabe?", "Não confia naquela Paz não.", "Ela fede!", "E seu nome?", "Pura piada por aqui.", "Cuidado pra não virar piada também, pequenino.", "Tchau tchau.", "Hihihi, Pequeno conselho para um pequeno amigo...", "Eu sou hilária!" };

                nextProgressionValue = 4;

                break;
        }

        dialogue.speechTxt = speech;
        dialogue.nextProgressionValue = nextProgressionValue;
    }

    #endregion
    //========================


}
