using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPC : MonoBehaviour
{
    public Misery miseryScript;
    public GameObject profile;
    public Sprite profileSprite;
    public float profileSize;
    public string[] speechTxt;
    public string actorName;
    public LayerMask playerLayer;
    public float radius;

    private DialogueControlNPC dcNPC; // Alteração: Usar DialogueControlGhost em vez de DialogueControl
    public bool onRadius; //private
    private bool isDialogueActive = false;

    public bool talking = false;
    public float nextProgressionValue;

    public void Talk(float funcProfileSize)
    {
        if (!talking && dcNPC.dialogueFinished)
        {
            talking = true;
            miseryScript.occupied = true;
            dcNPC.Speech(profileSprite, speechTxt, actorName, funcProfileSize); // Alteração: Chamar dcNPC.Speech em vez de dc.Speech
        }
    }

    private void Start()
    {
        dcNPC = FindObjectOfType<DialogueControlNPC>(); // Alteração: Usar DialogueControlGhost em vez de DialogueControl
    }

    private void FixedUpdate()
    {
        InteractiveDialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && talking && !dcNPC.dialogueFinished)
        {
            dcNPC.NextSentence();
            print("oie");
        }

        if (Input.GetKeyDown(KeyCode.Space) && onRadius && !talking && dcNPC.dialogueFinished)
        {
            print("comecou");
            miseryScript.occupied = true;
            talking = true;
            dcNPC.Speech(profileSprite, speechTxt, actorName, profileSize); // Alteração: Chamar dcNPC.Speech em vez de dc.Speech
        }

        if (Input.GetKeyDown(KeyCode.Space) && talking && dcNPC.dialogueFinished)
        {
            EndDialogue();
            talking = false;
            miseryScript.occupied = false;
            miseryScript.progression = nextProgressionValue;
        }
    }

    public void InteractiveDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerLayer);

        if (hit != null)
        {
            onRadius = true;
        }
        else
        {
            onRadius = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void EndDialogue()
    {
        isDialogueActive = false;
    }
}