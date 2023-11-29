using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peace: MonoBehaviour
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
                case 0:

                    speech = new string[] { "Ah não, o cara novo...", "Quer dizer, seja bem vindo!", "Sempre sobra pra mim ensinar esses novatos inúteis, então vamos lá.", "..........." };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 0.1f;

                    break;

                case 0.1f:

                    speech = new string[] { "................" };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 0.2f;

                    SwitchActor("Miséria", portraits[0], 1);

                    break;

                case 0.2f:

                    speech = new string[] { "ABRE A CARTA QUE VOCÊ RECEBEU!!!" };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 0.3f;

                    SwitchActor("PAZ", portraits[2], 2.3f);

                    break;

                case 0.3f:

                    speech = new string[] { "Isso.", "Aí dentro tem um deck de cartas.", "Você vai usar elas pra trabalhar pro Tempo.", "Se você sair daqui, vai ver que tem 3 ruas.", "E nessas ruas têm almas.", "Seu trabalho é invadir essas almas.", "Inclusive, estamos sem Tempo pra conversa.", "Vai invadir 5 almas, depois você volta.", "Só lembrando que as almas dessa rua aqui são mais fortes.", "Então elas valem por 3.", "As da rua do meio valem 2 almas.", "E as da rua de baixo valem por 1 mesmo.", "Se quiser se acostumar primeiro, sugiro ir na rua la em baixo.", "Tá esperando o que?" };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 0.4f;

                    SwitchActor("Paz", portraits[1], 1.7f);

                    break;

                case 0.4f:

                    speech = new string[] { "VAI TRABALHAR!!!" };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 0.5f;

                    SwitchActor("Paz", portraits[2], 2.3f);

                    break;

                case 0.5f:

                    speech = new string[] { "...." };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 0.6f;

                    SwitchActor("Paz", portraits[1], 1.7f);

                    break;

                case 0.6f:

                    if (miseryScript.defeatedGhosts < 5)
                    {
                        speech = new string[] { "Para de enrolar." };

                        dialogue.speechTxt = speech;
                        nextProgressionValue = 0.6f;
                    }

                    else
                    {
                        speech = new string[] { "Ótimo!", "Agora sugiro que você vá pro bar.", "Os imbecis vão querer te conhecer.", "Ou só vai direto pra casa dormir, sei lá.", "Só lembra de ir dormir depois.", "O último Miséria foi demitido porque sempre vinha trabalhar virado...", ".......", "Tá esperando o que?", "SOME." };

                        dialogue.speechTxt = speech;
                        nextProgressionValue = 1;
                    }

                    break;

                case 1:

                    speech = new string[] { "Meu contrato não me obriga a falar mais do que eu já falei com você." };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 1;

                    break;
            }

            dialogue.nextProgressionValue = nextProgressionValue;
        }
    }

    #endregion
    //========================


}
