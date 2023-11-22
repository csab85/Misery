using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card: MonoBehaviour
{
    //IMPORTS
    //========================
    #region

    [SerializeField] Button cardButton;
    [SerializeField] UnitBehaviour unit;
    [SerializeField] TextMeshProUGUI type;
    [SerializeField] TextMeshProUGUI cost;
    [SerializeField] TextMeshProUGUI damage;
    [SerializeField] TextMeshProUGUI health;

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
        
    }

    private void OnMouseOver()
    {
        print(name);
    }

    #endregion
    //========================


}
