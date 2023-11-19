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
            case 0:
                speech = new string[] { "Olá pequenino!", "Vamos andando, pois tenho muito trabalho para fazer.", "E não me julgue, mas uma nova adição como você, é um fardo pra mim.", "Só faço trabalhar mas sem receber nada em troca.", "Ehhh........", "Não que eu esteja reclamando!", "Ok, vamos continuar.", "...", "......", "...........................", ".......................................", "........................................................................", "ABRE A CARTA QUE VOCÊ RECEBEU, Ô DESGRAÇA", "Quer dizer, Miséria.", "Isso.", "Julgando que você não seja cego que nem o brutamontes do Preconceito...", "Acho que enxerga um deck de cartas acopladas na correspondência, certo?", "Você vai usar isso no seu trabalho.", "Lá fora tem umas almas nojentas...", "Aperte ESPAÇO perto de uma delas.", "E digamos que você vai se divertir um pouquinho com essas... almas", "Usando esse seu deck de cartas.", "Esse é o seu trabalho incrível.", "Poderia ter até Inveja de você se eu fosse aquele imbecil...", "O nosso chefe maravilhoso te deu um poder que somente ele pode dar...", "O TEMPO!!!", "......", "Quer dizer, uma forma de viajar no tempo.", "E não me venha com \"E isso é possível?\".", "Se eu disse que ele te deu esse poder então é possível, inferno.", "Não seja burro como as outras antas que trabalham por aqui.", "Quer dizer, o chefe te escolheu a dedo.", "Espero que você seja no mínimo UM POUCO inteligente.", "Mas voltando...", "Estamos no Além-Mundo.",  "Não confunda com o SUB-Mundo.", "Lá é onde as almas mortas vão, aqui ficam as almas das pessoas vivas.", "E por aqui nós temos objetivos terríveis...", "Para os humanos, claro!", "Ahn, o que eu tinha que falar mesmo...", "Ah é.", "Como você vai se divertir com as almas lá fora?", "VIAGEM NO TEMPO!!!", "É isso aí, você vai viajar pro passado dessas almas e deixá-las mais miseráveis.", "Afinal, seu nome não é “Miséria” à toa!", "Seu objetivo hoje é tornar 5 almas miseráveis.", "Só um aviso, as almas dessa rua aqui são mais difíceis de invadir.", "Então uma alma vale por 3.", "As da rua do meio valem por 2.", "E as da rua de baixo são fáceis, valem pro 1 mesmo", "Mas você decide quem você quer tornar miserável.", "Agora some daqui, só fala comigo quando tiver infernizado as 5 almas." };

                nextProgressionValue = 1;

                break;

            case 1:
                speech = new string[] { "rapaiz" };
                nextProgressionValue = 2;

                break;
        }

        dialogue.speechTxt = speech;
        dialogue.nextProgressionValue = nextProgressionValue;
    }

    #endregion
    //========================


}
