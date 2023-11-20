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
                speech = new string[] { "Ol� pequenino!", "Vamos andando, pois tenho muito trabalho para fazer.", "E n�o me julgue, mas uma nova adi��o como voc�, � um fardo pra mim.", "S� fa�o trabalhar mas sem receber nada em troca.", "Ehhh........", "N�o que eu esteja reclamando!", "Ok, vamos continuar.", "...", "......", "...........................", ".......................................", "........................................................................", "ABRE A CARTA QUE VOC� RECEBEU, � DESGRA�A!!", "......", "Isso.", "Julgando que voc� n�o seja cego que nem o brutamontes do Preconceito...", "Acho que enxerga um deck de cartas acopladas na correspond�ncia, certo?", "Voc� vai usar isso no seu trabalho.", "L� fora tem umas almas nojentas...", "Aperte ESPA�O perto de uma delas.", "E digamos que voc� vai se divertir um pouquinho com essas... almas", "Usando esse seu deck de cartas.", "Esse � o seu trabalho incr�vel.", "Poderia ter at� Inveja de voc� se eu fosse aquela imbecil...", "O nosso chefe maravilhoso te deu um poder que somente ele pode dar...", "O TEMPO!!!", "......", "Quer dizer, uma forma de viajar no tempo.", "E n�o me venha com \"E isso � poss�vel?\".", "Se eu disse que ele te deu esse poder ent�o � poss�vel, inferno.", "N�o seja burro como as outras antas que trabalham por aqui.", "Quer dizer, o chefe te escolheu a dedo.", "Espero que voc� seja no m�nimo UM POUCO inteligente.", "Mas voltando...", "Estamos no Al�m-Mundo.",  "N�o confunda com o SUB-Mundo.", "L� � onde as almas mortas v�o, aqui ficam as almas das pessoas vivas.", "E por aqui n�s temos objetivos terr�veis...", "Para os humanos, claro!", "Ahn, o que eu tinha que falar mesmo...", "Ah �.", "Como voc� vai se divertir com as almas l� fora?", "VIAGEM NO TEMPO!!!", "� isso a�, voc� vai viajar pro passado dessas almas e deix�-las mais miser�veis.", "Afinal, seu nome n�o � �Mis�ria� � toa!", "Seu objetivo hoje � tornar 5 almas miser�veis.", "S� um aviso, as almas dessa rua aqui s�o mais dif�ceis de invadir.", "Ent�o uma alma vale por 3.", "As da rua do meio valem por 2.", "E as da rua de baixo s�o f�ceis, valem pro 1 mesmo", "Mas voc� decide quem voc� quer tornar miser�vel.", "Agora some daqui, s� fala comigo quando tiver infernizado as 5 almas." };

                nextProgressionValue = 1;

                break;

            case 1:
                speech = new string[] { "Por hoje seu trabalho t� encerrado.", "S� tenho uma coisa a acrescentar para voc�, antes de pararmos com o papo de trabalho.", "N�o ouse descumprir as ordens do Tempo, fa�a sempre o que ele mandar.", "Seus erros de hoje, ele ir� desconsiderar, pois voc� estava aprendendo.", "Aqui n�o h� espa�os para erros, entendeu?", "Ali�s, me pediram pra te dar um aviso.", "Tem um bar na rua mais em baixo.", "Esse local na parte pobre desse mundo.", "Junto com a sua nova casa.", "Logo mais voc� se acostuma com seu novo lar.", "Enfim...", "L� voc� vai encontrar todos os seus colegas de trabalhos in�teis.", "Outra dica, s� n�o mexa com a morte.", "Ela � a �nica daqui que tenho algum tipo de respeito...", "Quero dizer, j� a viu?", "Ela � assustadora!", "E a Viol�ncia...", "Essa deveria ter o nome de TRA�RA ou de INVEJOSA.", "ISSO SIM!", "......", "......", "E outra coisa", "S� � pra voc� ir no bar DEPOIS DO EXPEDIENTE.", "Ok, acho que era isso.", "Pode ir pra casa j�, ningu�m vai querer falar com o novato no primeiro dia.", "To te falando isso pra poupar voc� da vergonha de tomar v�cuo.", "Quem avisa amigo �.", "........", "N�O QUE EU SEJA SUA AMIGA!", "......", "Mas quem sabe amanh� algum dos imbecis conversa com voc� no bar.", "Agora vai dormir, sai da minha frente.", "TCHAU!" };

                nextProgressionValue = 2;

                break;

            case 2:
                speech = new string[] { "(provis�rio)", "Vai pegar 4 almas" };

                nextProgressionValue = 3;

                break;

            case 3:
                speech = new string[] { "(provisorio)", "Tu pegou as alma, eba" };

                nextProgressionValue = 4;

                break;
        }

        dialogue.speechTxt = speech;
        dialogue.nextProgressionValue = nextProgressionValue;
    }

    #endregion
    //========================


}
