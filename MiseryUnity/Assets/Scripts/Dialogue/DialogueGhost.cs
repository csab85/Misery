using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueGhost : MonoBehaviour
{
    public Sprite profile;
    public string[] speechTxt;
    public string actorName;
    public LayerMask playerLayer;
    public float radius;

    private DialogueControlGhost dcGhost; // Alteração: Usar DialogueControlGhost em vez de DialogueControl
    private bool onRadius;
    private bool isDialogueActive = false;

    private void Start()
    {
        dcGhost = FindObjectOfType<DialogueControlGhost>(); // Alteração: Usar DialogueControlGhost em vez de DialogueControl
    }

    private void FixedUpdate()
    {
        InteractiveDialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onRadius && !isDialogueActive)
        {
            isDialogueActive = true;
            dcGhost.Speech(profile, speechTxt, actorName); // Alteração: Chamar dcGhost.Speech em vez de dc.Speech
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