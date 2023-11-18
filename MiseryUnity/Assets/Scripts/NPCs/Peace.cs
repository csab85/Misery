using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peace: MonoBehaviour
{
    //IMPORTS
    //========================
    #region

    public Misery miseryScript;
    public Dialogue dialogue;

    #endregion
    //========================


    //STATS AND VALUES
    //========================
    #region

    string[] speech;

    #endregion
    //========================


    //FUNCTIONS
    //========================
    #region



    #endregion
    //========================


    //RUNNING
    //========================
    #region

    //Start
    void Start()
    {

    }

    //Update
    void Update()
    {
        switch (miseryScript.progression)
        {
            case 0:

                speech = new string[] {"Oi meu bom", "Tá  safo?"};
                print("ja foi");
                break;
        }

        dialogue.speechTxt = speech;
    }

    #endregion
    //========================


}
