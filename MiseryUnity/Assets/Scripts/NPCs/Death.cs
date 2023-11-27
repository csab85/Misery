using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
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
        if (dialogue.onRadius)
        {
            switch (miseryScript.progression)
            {
                case 1:

                    speech = new string[] { "GRRRRRRRR!" };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 1.1f;

                    break;

                case 1.1f:

                    speech = new string[] { "..." };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 1.2f;

                    SwitchActor("Mis�ria", portraits[0]);

                    break;

                case 1.2f:

                    speech = new string[] { "Hnghh." };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 1.3f;

                    SwitchActor("Morte", portraits[1]);

                    break;

                case 1.3f:

                    speech = new string[] { "Hm." };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 1.4f;

                    SwitchActor("Mis�ria", portraits[0]);

                    break;

                case 1.4f:

                    speech = new string[] { "Raagh." };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = 1;

                    SwitchActor("Morte", portraits[1]);

                    break;

                default:

                    speech = new string[] { "..." };

                    dialogue.speechTxt = speech;
                    nextProgressionValue = miseryScript.progression;

                    break;
            }

            dialogue.nextProgressionValue = nextProgressionValue;
        }
    }

    #endregion
    //========================


}
