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
    float selfRadius;

    #endregion
    //========================


    //FUNCTIONS
    //========================
    #region

    void Unexplode()
    {
        print("unexplode");
        GetComponent<Animator>().SetBool("exploding", false);
        transform.localScale = new Vector3(1, 1, 1);
        GetComponent<CircleCollider2D>().radius = selfRadius;
        state = "static";
    }

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

        affectedTargets.Add("Damaged");

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

                GetComponent<SpriteRenderer>().enabled = false;
                transform.position = transform.parent.transform.position;
                break;

                #endregion

            case "moving":
                #region

                //point towards enemy
                transform.LookAt(unitScript.enemy.transform, Vector3.forward);

                //distance
                float distance = Vector3.Distance(transform.position, transform.parent.transform.position);

                if (distance > 5)
                {
                    state = "static";
                }

                GetComponent<Rigidbody2D>().velocity = unitScript.direction * unitScript.attackSpeed;
                GetComponent<SpriteRenderer>().enabled = true;

                break;

            #endregion

            case "exploding":
                #region

                transform.localScale = new Vector3(1, 1, 1);
                GetComponent<CircleCollider2D>().radius = unitScript.aoe;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Animator>().SetBool("exploding", true);
                print("explode");

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
                state = "exploding";
            }

            if (unitScript.aoe <= 0)
            {
                state = "static";
            }

            if (collision.tag == "Building")
            {
                collision.GetComponent<Nexus>().damageTaken = unitScript.damage;
                collision.tag = "Damaged";
            }

            else if (collision.tag != "Damaged")
            {
                collision.GetComponent<UnitBehaviour>().damageTaken = unitScript.damage;
                collision.tag = "Damaged";
            }
        }
    }

    #endregion
    //========================


}
