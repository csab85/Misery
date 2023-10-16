using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehaviour : MonoBehaviour
{
    //IMPORTS
    //========================
    #region

    public EgoMap egoMap;

    #endregion
    //========================


    //STATS AND VALUES
    //========================
    #region

    //State
    public string state;

    //Movement
    public float speed;
    Vector3 velocity;
    public Vector3 maxVelocity;
    public float acceleration;



    #endregion
    //========================


    //FUNCTIONS
    //========================
    #region

    void Walk(string direction)
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            velocity.x = Input.GetAxis("Horizontal") * acceleration;
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            velocity.y = Input.GetAxis("Vertical") * acceleration;
        }

        //move
        if (velocity != new Vector3(0, 0, 0))
        {
            transform.position += velocity * Time.deltaTime;
        }
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

    }

    #endregion
    //========================


}
