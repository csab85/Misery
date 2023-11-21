using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    //IMPORTS
    //========================
    #region

    UnitBehaviour targetScript;
    [SerializeField] UnitBehaviour unitScript; //the unit this shot is attached 

    #endregion
    //========================


    //STATS AND VALUES
    //========================
    #region

    //State
    public string state = "static";

    //Targets affcted
    public List<string> affectedTargets;

    //Gambiarra
    public bool exploding = false;
    float selfRadius;

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
        //sync to its unit targets
        if (unitScript.targetAlly)
        {
            affectedTargets.Add("Ally");
        }

        if (unitScript.targetEnemy)
        {
            affectedTargets.Add("Enemy");
        }

        if (unitScript.targetBuilding)
        {
            affectedTargets.Add("Building");
        }

        //sync radius
        selfRadius = GetComponent<CircleCollider2D>().radius;
    }

    //Update
    void Update()
    {
        switch (state)
        {
            case "static":
                #region

                GetComponent<CircleCollider2D>().radius = selfRadius;
                GetComponent<SpriteRenderer>().enabled = false;
                transform.position = transform.parent.transform.position;
                break;

                #endregion

            case "moving":
                #region

                if (Mathf.Abs(transform.position.x - transform.parent.transform.position.x) > 5 | Mathf.Abs(transform.position.y - transform.parent.transform.position.y) > 5)
                {
                    state = "static";
                }

                GetComponent<SpriteRenderer>().enabled = true;

                break;

            #endregion

            case "exploding":
                #region

                if (exploding)
                {
                    //exploding animation and make exploding bool chage to false when animation finished
                    GetComponent<Animator>().SetBool("Exploding", true);
                }

                break;

                #endregion
        }
    }

    //Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (affectedTargets.Contains(collision.tag))
        {
            if (unitScript.aoe > 0)
            {
                GetComponent<CircleCollider2D>().radius = unitScript.aoe;
                return;
            }

            else
            {
                state = "static";
                collision.GetComponent<UnitBehaviour>().damageTaken = unitScript.damage;
                collision.tag = "Damaged";
            }
        }
    }
 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (affectedTargets.Contains(collision.tag))
        {
            if (!exploding)
            {
                state = "exploding";
                collision.tag = "Damaged";
            }
        }
    }

    #endregion
    //========================


}
