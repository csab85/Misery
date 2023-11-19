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
                speech = new string[] { "Ol� pequenino!", "Vamos andando, pois tenho muito trabalho para fazer.", "E n�o me julgue, mas uma nova adi��o como voc�, � um fardo pra mim.", "S� fa�o trabalhar mas sem receber nada em troca.", "Ehhh........", "N�o que eu esteja reclamando!", "Ok, vamos continuar.", "...", "......", "...........................", ".......................................", "........................................................................", "ABRE A CARTA QUE VOC� RECEBEU, � DESGRA�A", "Quer dizer, Mis�ria.", "Isso.", "Julgando que voc� n�o seja cego que nem o brutamontes do Preconceito...", "Acho que enxerga um deck de cartas acopladas na correspond�ncia, certo?", "Voc� vai usar isso no seu trabalho.", "L� fora tem umas almas nojentas...", "Aperte ESPA�O perto de uma delas.", "E digamos que voc� vai se divertir um pouquinho com essas... almas", "Usando esse seu deck de cartas.", "Esse � o seu trabalho incr�vel.", "Poderia ter at� Inveja de voc� se eu fosse aquele imbecil...", "O nosso chefe maravilhoso te deu um poder que somente ele pode dar...", "O TEMPO!!!", "......", "Quer dizer, uma forma de viajar no tempo.", "E n�o me venha com \"E isso � poss�vel?\".", "Se eu disse que ele te deu esse poder ent�o � poss�vel, inferno.", "N�o seja burro como as outras antas que trabalham por aqui.", "Quer dizer, o chefe te escolheu a dedo.", "Espero que voc� seja no m�nimo UM POUCO inteligente.", "Mas voltando...", "Estamos no Al�m-Mundo.",  "N�o confunda com o SUB-Mundo.", "L� � onde as almas mortas v�o, aqui ficam as almas das pessoas vivas.", "E por aqui n�s temos objetivos terr�veis...", "Para os humanos, claro!", "Ahn, o que eu tinha que falar mesmo...", "Ah �.", "Como voc� vai se divertir com as almas l� fora?", "VIAGEM NO TEMPO!!!", "� isso a�, voc� vai viajar pro passado dessas almas e deix�-las mais miser�veis.", "Afinal, seu nome n�o � �Mis�ria� � toa!", "Seu objetivo hoje � tornar 5 almas miser�veis.", "S� um aviso, as almas dessa rua aqui s�o mais dif�ceis de invadir.", "Ent�o uma alma vale por 3.", "As da rua do meio valem por 2.", "E as da rua de baixo s�o f�ceis, valem pro 1 mesmo", "Mas voc� decide quem voc� quer tornar miser�vel.", "Agora some daqui, s� fala comigo quando tiver infernizado as 5 almas." };

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
