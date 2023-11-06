using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeSyncronizer : MonoBehaviour
{
    //IMPORTS
    //========================
    #region

    public UnitBehaviour parentUnitScript;

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
        GetComponent<CircleCollider2D>().radius = parentUnitScript.range;
    }

    //Update
    void Update()
    {

    }

    #endregion
    //========================


}
