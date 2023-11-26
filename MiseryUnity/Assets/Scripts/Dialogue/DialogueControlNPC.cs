using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControlNPC : MonoBehaviour
{
    [Header("Components")]
    public GameObject DialogueObject;
    public GameObject profile;
    public Image profileImage;
    public TextMeshProUGUI speechText;
    public TextMeshProUGUI actorNameText;

    [Header("Settings")]
    public float typingSpeed;
    public string[] sentences; //privado
    private int index; //privado

    public bool dialogueFinished = true;

    public void Speech(Sprite p, string[] txt, string actorName, float profileSize)
    {
        DialogueObject.SetActive(true);
        profileImage.sprite = p;
        profile.transform.localScale = new Vector3(profileSize, profileSize, profileSize);
        sentences = txt;
        actorNameText.text = actorName;
        dialogueFinished = false;
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
        print(speechText.text);
        print(sentences[index]);
        if (speechText.text == sentences[index])
        {
            // ainda tem texto
            if (index < sentences.Length - 1)
            {
                print("tem textp");
                index++; //pulo para próxima fase
                speechText.text = ""; //limpo o texto
                StartCoroutine(TypeSentence()); //chama a próxima frase
            }
            else //lido quando acaba os textos
            {
                print("n tem texto");
                speechText.text = ""; //limpeza do texto
                index = 0; // valor do index 0 para poder voltar ao início do painel, ou poder falar com ele denovo
                DialogueObject.SetActive(false);
                dialogueFinished = true;
            }
        }
    }

    internal void AdvanceSpeech()
    {
        throw new System.NotImplementedException();
    }
}
