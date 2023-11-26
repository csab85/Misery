using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peace: MonoBehaviour
{
    //IMPORTS
    //========================
    #region

    public Misery miseryScript;
    public DialogueNPC dialogue;
    [SerializeField] Sprite[] portraits;

    #endregion
    //========================


    //STATS AND VALUES
    //========================
    #region

    string[] speech;
    float nextProgressionValue;

    #endregion
    //========================


    //FUNCTIONS
    //========================
    #region

    /// <summary>
    /// Switches the current profile pic and actor name mid dialogue
    /// </summary>
    /// <param name="name">The new name</param>
    /// <param name="portrait">The new profile pic</param>
    /// <param name="funcProfileSize">The new profile pic scale</param>
    void SwitchActor(string name, Sprite portrait, float funcProfileSize = 1)
    {
        dialogue.actorName = name;

        dialogue.profile.transform.localScale = new Vector3(funcProfileSize, funcProfileSize, funcProfileSize);
        dialogue.profileSprite = portrait;
        
        dialogue.Talk(funcProfileSize);
    }

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

                speech = new string[] { "Olá pequenino!", "ta bao?" };
                dialogue.speechTxt = speech;
                nextProgressionValue = 0.1f;

                break;

            case 0.1f:

                speech = new string[] { "oi" };
                dialogue.speechTxt = speech;
                nextProgressionValue = 0.2f;

                SwitchActor("Misery", portraits[0], 1);

                
                

                break;

            case 0.2f:

                speech = new string[] { "Vamos andando" };
                dialogue.speechTxt = speech;
                nextProgressionValue = 1;

                SwitchActor("Paz", portraits[1], 1.7f);

                break;
        }

        dialogue.nextProgressionValue = nextProgressionValue;
    }

    #endregion
    //========================


}
