using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    //IMPORTS
    //========================
    #region



    #endregion
    //========================


    //STATS AND VALUES
    //========================
    #region

    //State
    public string state = "static";

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
        switch (state)
        {
            case "static":
                #region



                transform.position = transform.parent.transform.position;
                break;

                #endregion

            case "moving":
                #region

                if (Mathf.Abs(transform.position.x - transform.parent.transform.position.x) > 5 | Mathf.Abs(transform.position.y - transform.parent.transform.position.y) > 5)
                {
                    state = "static";
                }

                break;

                #endregion
        }
    }

    //Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tag == "Ground Ally Shot" | tag == "Air Ally Shot")
        {
            if (collision.tag == "Air Enemy" | collision.tag == "Ground Enemy")
            {
                state = "static";
            }
        }

        if (tag == "Ground Enemy Shot" | tag == "Air Enemy Shot")
        {
            if (collision.tag == "Air Ally" | collision.tag == "Ground Ally")
            {
                state = "static";
            }
        }
    }

    #endregion
    //========================


}
