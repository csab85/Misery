using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    [TextArea]
    public string[] speechTxt;
    public DialogueStruct[] speechPlayer;
    public string actorName;
    public LayerMask playerLayer;
    public float radius;

    private DialogueControl dc;
    private bool onRadius;
    private bool isDialogueActive = false; // Vari�vel para verificar se o di�logo est� ativo

    private void Start()
    {
        dc = FindObjectOfType<DialogueControl>();
    }

    private void FixedUpdate()
    {
        InteractiveDialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onRadius && !isDialogueActive) // Verifica se o di�logo n�o est� ativo
        {
            isDialogueActive = true; // Ativa o di�logo
            dc.Speech(profile, actorName, speechPlayer);
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

    // M�todo chamado pelo DialogueControl quando o di�logo termina
    public void EndDialogue()
    {
        isDialogueActive = false; // Desativa o di�logo
    }
}