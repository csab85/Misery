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
        //delete ball if gets too far
    }

    //Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyGround")
        {
            transform.position = transform.parent.transform.position;
        }
    }

    #endregion
    //========================


}
