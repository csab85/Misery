using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliders : MonoBehaviour
{
    [SerializeField] Misery miseryScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (miseryScript.invading)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }

        else
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
