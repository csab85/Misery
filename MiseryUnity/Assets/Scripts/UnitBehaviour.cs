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
    Vector3 velocity;
    public Vector3 maxVelocity;
    public float acceleration;
    public float deceleration;

    public float walkDistance;

    //Function progresssion
    //walk
    int side = 0;

    //read path
    int pathStep = 0;
    float movement = 0;

    #endregion
    //========================


    //FUNCTIONS
    //========================
    #region

    /// <summary>
    /// Moves towards direction given
    /// </summary>
    /// <param name="direction">The direction to move (if its none it'll slowly stop moving)</param>
    void Walk(string direction)
    {

        if (direction == "Right" | direction == "Up")
        {
            side = 1;
        }

        if (direction == "Left" | direction == "Down")
        {
            side = -1;
        }

        //get input
        if (direction == "Right" | direction == "Left")
        {
            velocity.x = Mathf.MoveTowards(velocity.x, (maxVelocity.x * side), acceleration * Time.deltaTime);
        }

        if (direction == "Up" | direction == "Down")
        {
            velocity.y = Mathf.MoveTowards(velocity.y, (maxVelocity.y * side), acceleration * Time.deltaTime);
        }
        
        if (direction == "none")
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
            velocity.y = Mathf.MoveTowards(velocity.y, 0, deceleration * Time.deltaTime);
        }

        //move
        if (velocity != new Vector3(0, 0, 0))
        {
            transform.position += velocity * Time.deltaTime;
        }
    }

    /// <summary>
    /// Reads the path given, and makes the unit walk following its directions
    /// </summary>
    /// <param name="path">The path to be followed</param>
    void ReadPath(List<string> path)
    {
        Walk(egoMap.path[pathStep]);

        if (egoMap.path[pathStep] == "Right" | egoMap.path[pathStep] == "Left")
        {
            movement += velocity.x * Time.deltaTime;
        }

        if (egoMap.path[pathStep] == "Up" | egoMap.path[pathStep] == "Down")
        {
            movement += velocity.y * Time.deltaTime;
        }

        if (movement >= walkDistance)
        {
            movement = 0;
            pathStep += 1;
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
        if (egoMap.pathPainted)
        {
            ReadPath(egoMap.path);
        }
        
    }

    #endregion
    //========================


}
