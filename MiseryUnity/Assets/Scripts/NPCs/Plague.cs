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
                speech = new string[] { "T�o bom te conhecer finalmente Mis�ria!", "T�o bom te conhecer finalmente Mis�ria!", "......", "Voc� tinha que falar junto comigo?", "Foi mal, maninho, s� saiu!", "Olha, Mis�ria, n�o liga pra esse carinha aqui, ele � rabugento!", "Rabugento? Eu? Hmpf.", "� de poucas palavras, meu amigo?", "Cuidado pra n�o acabar virando um estraga prazeres como esse cara aqui.", "Ele teria sorte em ser mais parecido comigo do que com voc�.", "Pra que essa felicidade exagerada quando o mundo � t�o azul...", "Melanc�lico como sempre, maninho?", "N�o desanima o carinha aqui...", "De qualquer jeito, pega uma bebida e senta aqui com a gente.", "Voc� tinha que falar demais mesmo? Tagarela bocudo.", "Voc� n�o achou ele muito diferente do outro...", "Cala a boca, idiota!" };

                nextProgressionValue = 4;

                break;
        }

        dialogue.speechTxt = speech;
        dialogue.nextProgressionValue = nextProgressionValue;
    }

    #endregion
    //========================


}
