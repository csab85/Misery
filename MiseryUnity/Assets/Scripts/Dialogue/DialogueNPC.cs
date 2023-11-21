using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPC : MonoBehaviour
{
    public Misery miseryScript;
    public Sprite profile;
    public string[] speechTxt;
    public string actorName;
    public LayerMask playerLayer;
    public float radius;

    private DialogueControlNPC dcNPC; // Alteração: Usar DialogueControlGhost em vez de DialogueControl
    private bool onRadius;
    private bool isDialogueActive = false;

    bool talking = false;
    public float nextProgressionValue;

    public void Talk()
    {
        print("aaAAA");
        if (!talking && dcNPC.dialogueFinished)
        {
            talking = true;
            dcNPC.Speech(profile, speechTxt, actorName); // Alteração: Chamar dcNPC.Speech em vez de dc.Speech
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
        if (Input.GetKeyDown(KeyCode.Space) && onRadius && !talking && dcNPC.dialogueFinished)
        {
            talking = true;
            dcNPC.Speech(profile, speechTxt, actorName); // Alteração: Chamar dcNPC.Speech em vez de dc.Speech
        }

        if (Input.GetKeyDown(KeyCode.Space) && onRadius && talking && !dcNPC.dialogueFinished)
        {
            dcNPC.NextSentence();
        }

        if (Input.GetKeyDown(KeyCode.Space) && onRadius && talking && dcNPC.dialogueFinished)
        {
            EndDialogue();
            talking = false;
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