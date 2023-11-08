using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//Nesse script terá informações gerais do nosso sitema de dialogo, precisamos referendiar a caixa de dialogo, imagem que aparecerá, o texto e etc
public class DialogueControl : MonoBehaviour
{
    [Header("Components")] //cabeçalho que organiza melhor no inspector
    public GameObject DialogueObject; //a janela do dialogo, precisamos referênciar ele para poder ativar e desativar quando necessário
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

    //Criação de um método que vai ser chamado do npc, para poder chamar o dialogo
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

    public void NextSentece()     //passar para as próximas frases
    {
        Debug.Log("chamou funçãi");
        if(speechText.text == sentences[index])
        {
            // ainda tem texto
            Debug.Log("chamou sentence");
            if (index < sentences.Length - 1)
            {
                Debug.Log("próxima frase");
                index++; //pulo para próxima fase
                speechText.text = ""; //limpo o texto
                StartCoroutine(TypeSentence()); //chama a próxima frase
            }
            else //lido quando acaba os textos
            {
                speechText.text = ""; //limpeza do texto
                index = 0; // valor do index 0 para poder voltar ao início do painel, ou poder falar com ele denovo
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
