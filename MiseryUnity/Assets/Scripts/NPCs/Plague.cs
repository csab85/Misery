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
                speech = new string[] { "Tão bom te conhecer finalmente Miséria!", "Tão bom te conhecer finalmente Miséria!", "......", "Você tinha que falar junto comigo?", "Foi mal, maninho, só saiu!", "Olha, Miséria, não liga pra esse carinha aqui, ele é rabugento!", "Rabugento? Eu? Hmpf.", "É de poucas palavras, meu amigo?", "Cuidado pra não acabar virando um estraga prazeres como esse cara aqui.", "Ele teria sorte em ser mais parecido comigo do que com você.", "Pra que essa felicidade exagerada quando o mundo é tão azul...", "Melancólico como sempre, maninho?", "Não desanima o carinha aqui...", "De qualquer jeito, pega uma bebida e senta aqui com a gente.", "Você tinha que falar demais mesmo? Tagarela bocudo.", "Você não achou ele muito diferente do outro...", "Cala a boca, idiota!" };

                nextProgressionValue = 4;

                break;
        }

        dialogue.speechTxt = speech;
        dialogue.nextProgressionValue = nextProgressionValue;
    }

    #endregion
    //========================


}
