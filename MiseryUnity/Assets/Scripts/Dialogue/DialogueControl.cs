using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//Nesse script ter� informa��es gerais do nosso sitema de dialogo, precisamos referendiar a caixa de dialogo, imagem que aparecer�, o texto e etc
public class DialogueControl : MonoBehaviour
{
    [Header("Components")] //cabe�alho que organiza melhor no inspector
    public GameObject DialogueObject; //a janela do dialogo, precisamos refer�nciar ele para poder ativar e desativar quando necess�rio
    public Image profile;
    public TextMeshProUGUI speechText;
    public TextMeshProUGUI actorNameText;
    public Button bootA;
    public Button bootB;
    public TextMeshProUGUI bootAText;
    public TextMeshProUGUI bootBText;
    public DialogueStruct[] dialogues;

    [Header("Settings")]
    public float typingSpeed; //Vai servir para adicionar uma velocidade para o texto aparecer
    private string[] sentences;
    private int index;
    private int indexD;

    //Cria��o de um m�todo que vai ser chamado do npc, para poder chamar o dialogo
    public void Speech(Sprite p, string actorName, DialogueStruct[] talk)
    {
        /*DialogueObject.SetActive(true);  //precisamos passar alguns argumentos para esse metodo, como chamaremos ele diretos do npc, precisamos referenciar o texto, a imagem e o nome dele
        profile.sprite = p;
        sentences = txt;
        actorNameText.text = actorName;
        StartCoroutine(TypeSentence());*/
        dialogues = talk;
        DialogueObject.SetActive(true);
        profile.sprite = p;
        sentences = dialogues[indexD].text;
        if (dialogues[indexD].isInteractive)
        {
            bootA.enabled = true;
            bootB.enabled = true;
            bootAText.text = dialogues[indexD].optionA;
            bootBText.text = dialogues[indexD].optionB;
           
        }
        actorNameText.text = actorName;
        StartCoroutine(TypeSentence()); 
    }

    IEnumerator TypeSentence()   //efeito de aparecer uma letra de cada vez
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }
    }

    public void NextSentece()     //passar para as pr�ximas frases
    {
        Debug.Log("chamou fun��i");
        if(speechText.text == sentences[index])
        {
            // ainda tem texto
            Debug.Log("chamou sentence");
            if (index < sentences.Length - 1)
            {
                Debug.Log("pr�xima frase");
                index++; //pulo para pr�xima fase
                speechText.text = ""; //limpo o texto
                StartCoroutine(TypeSentence()); //chama a pr�xima frase
            }
            else //lido quando acaba os textos
            {
                speechText.text = ""; //limpeza do texto
                index = 0; // valor do index 0 para poder voltar ao in�cio do painel, ou poder falar com ele denovo
                if (indexD < dialogues.Length - 1)
                {
                    Debug.Log("next");
                    indexD++;
                    Speech(profile.sprite, actorNameText.text, dialogues);
                    StartCoroutine(TypeSentence());
                }
               
            }

        }
        else
        {
            Debug.Log("desativou");
            DialogueObject.SetActive(false);
        }
    }

    internal void AdvanceSpeech()
    {
        throw new NotImplementedException();
    }
}
