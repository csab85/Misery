using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehaviour : MonoBehaviour
{
    //IMPORTS
    //========================
    #region

    public EgoMap egoMap;
    //enemy script

    #endregion
    //========================


    //STATS AND VALUES
    //========================
    #region

    //State (walking, attacking)
    public string state = "walking";

    //Movement
    public Vector3 velocity;
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
    Vector3 initialPosit;
    public Vector3 expectedPosit;

    //Range and attacking
    GameObject enemy;

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

        if (direction == "right" | direction == "up")
        {
            side = 1;
        }

        if (direction == "left")
        {
            side = -1;
        }

        //get input
        if (direction == "right" | direction == "left")
        {
            velocity.x = Mathf.MoveTowards(velocity.x, (maxVelocity.x * side), acceleration * Time.deltaTime);
        }

        if (direction == "up")
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
        //Walk(path[pathStep]);

        if (movement == 0)
        {
            initialPosit = transform.position;
            expectedPosit = initialPosit;

            if (path[pathStep] == "right" | path[pathStep] == "left")
            {
                expectedPosit.x += walkDistance * side;
            }

            if (path[pathStep] == "up")
            {
                expectedPosit.y += walkDistance;
            }
        }

        if (egoMap.path[pathStep] == "right" | egoMap.path[pathStep] == "up")
        {
            side = 1;
        }

        if (egoMap.path[pathStep] == "left")
        {
            side = -1;
        }

        if (transform.position.x < expectedPosit.x | transform.position.x > expectedPosit.x)
        {
            movement += Mathf.Abs(velocity.x * Time.deltaTime);
            velocity.x = Mathf.MoveTowards(velocity.x, (maxVelocity.x * side), acceleration * Time.deltaTime);
            
        }

        if (transform.position.y < expectedPosit.y)
        {
            velocity.y = Mathf.MoveTowards(velocity.y, (maxVelocity.y * side), acceleration * Time.deltaTime);
            movement += velocity.y * Time.deltaTime;
        }

        //move
        if (velocity != new Vector3(0, 0, 0))
        {
            transform.position += velocity * Time.deltaTime;
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
        switch (state)
        {
            case "walking":
                #region

                if (egoMap.voidPainted && egoMap.pathPainted)
                {
                    ReadPath(egoMap.path);
                }

                break;

            #endregion

            case "attacking":
                #region

                if (enemy.tag == "Dead")
                {
                    state = "walking";
                }

                break;

                #endregion
        }
    }

    //Range trigger
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "EnemyAir" | collision.tag == "EnemyGround")
        {
            enemy = collision.gameObject;
            state = "attacking";
        }
    }

    #endregion
    //========================


}
