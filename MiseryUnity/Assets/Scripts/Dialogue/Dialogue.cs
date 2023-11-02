using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Sprite profile; //sprite
    public string[] speechTxt; //texto
    public string actorName; //nome dele

    public LayerMask playerLayer;        //permite referenciar uma layer que a gente tenha criado
    public float radius;                 //vai nos dar o tamanho do colisor

    //precisamos refer�nciar o dialogue control, a classe que t� tendo o controle, precisamos chamar um metodo dela
    private DialogueControl dc;
    bool onRadius;

    private void Start()
    {
        dc = FindObjectOfType<DialogueControl>(); //refer�ncia o script dialogue control
    }

    private void FixedUpdate()               //quando tiver trabalhando com f�sica � melhor fixedUpdate
    {
        InteractiveDialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onRadius)
        {
            dc.Speech(profile, speechTxt, actorName);
        }
    }
    public void InteractiveDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerLayer);     //no overlapCircle, entre os parenteses preciso passar a posi��o, o tamanho e a layer que ele ir� interagir

        if (hit != null)
        {
           onRadius = true;
        }
        else
        {
            onRadius = false;
        }
    }

    private void OnDrawGizmosSelected()    //serve para mostrar o guizmo dos personagens
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
