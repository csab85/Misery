using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    //IMPORTS
    //========================
    #region

    TextMesh textMesh;

    #endregion
    //========================

    //RUNNING
    //========================
    #region

    //Start
    void Start()
    {
        textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.text = "BATATA";
    }

    //Update
    void Update()
    {
        
    }

     #endregion
    //========================
}
