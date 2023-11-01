using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrulhamento : MonoBehaviour
{
    bool right = true; //uso do verdadeiro ou falso 
    public float limiteEsq, limiteDir; //cria��o de abinhas na unity pro controle da dire��o
    // Start is called before the first frame update
    void Start()
    {
       //transform.position = new Vector3(0.49f,2.6f,0);
      // transform.position = new Vector3(0.49f,2.6f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(-2.61f, -0.27, 0);
        //transform.position = transform.position + new vector3(0.001f, 0, 0);
        /* if (transform.position.x > 3.1f);
         {
        transform.position = new vector3(-3, 0, 0);
        }
        else
        {
        transform.position += new vector3(0.001f, 0, 0):
        }
        }*/
        if (right)
        {
            transform.position += new Vector3(0.005f, 0, 0); // Se est� indo para a direita, adiciona � posi��o no eixo X
            if (transform.position.x > limiteDir)
            {
                // Se atingir o limite direito, inverte a dire��o e vira o objeto 180 graus
                right = false;
                transform.rotation = Quaternion.Euler(0,180, 0);
            }
        }
        else
        {
            // Se est� indo para a esquerda, subtrai da posi��o no eixo X
            transform.position -= new Vector3(0.005f, 0, 0);
            if (transform.position.x < limiteEsq)
            {
                // Se atingir o limite esquerdo, inverte a dire��o e vira o objeto 0 grau (voltando � posi��o inicial)
                right = true;
                transform.rotation = Quaternion.Euler(0,0,0);
            }
        }
        
    }
}
