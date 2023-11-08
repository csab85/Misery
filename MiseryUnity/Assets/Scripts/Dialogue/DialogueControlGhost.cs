using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControlGhost : MonoBehaviour
{
    [Header("Components")]
    public GameObject DialogueObject;
    public Image profile;
    public TextMeshProUGUI speechText;
    public TextMeshProUGUI actorNameText;

    [Header("Settings")]
    public float typingSpeed;
    private string[] sentences;
    private int index;

    public void Speech(Sprite p, string[] txt, string actorName)
    {
        DialogueObject.SetActive(true);
        profile.sprite = p;
        sentences = txt;
        actorNameText.text = actorName;
        StartCoroutine(TypeSentence());
    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if (speechText.text == sentences[index])
        {
            // ainda tem texto
            if (index < sentences.Length - 1)
            {
                index++; //pulo para próxima fase
                speechText.text = ""; //limpo o texto
                StartCoroutine(TypeSentence()); //chama a próxima frase
            }
            else //lido quando acaba os textos
            {
                speechText.text = ""; //limpeza do texto
                index = 0; // valor do index 0 para poder voltar ao início do painel, ou poder falar com ele denovo
                DialogueObject.SetActive(false);
            }
        }
    }

    internal void AdvanceSpeech()
    {
        throw new System.NotImplementedException();
    }
}
