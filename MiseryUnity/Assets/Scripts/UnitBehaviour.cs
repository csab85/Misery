using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehaviour : MonoBehaviour
{
    //IMPORTS
    //========================
    #region

    public EgoMap egoMap;
    public GameObject shot;
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
    public int pathStep = 0;
    public float movement = 0;
    bool decelerating = false;
    public Vector3 initialPosit;

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
        transform.position += velocity * Time.deltaTime;
    }

    /// <summary>
    /// Reads the path given, and makes the unit walk following its directions
    /// </summary>
    /// <param name="path">The path to be followed</param>
    void ReadPath(List<string> path)
    {
        //setup
        if (movement == 0)
        {
            initialPosit = transform.position;
        }


        //walk func
        if (!decelerating)
        {
            Walk(path[pathStep]);
        }


        //decelerate
        if (decelerating)
        {
            if (egoMap.path[pathStep] == "right" | egoMap.path[pathStep] == "left")
            {
                float displacement = (Mathf.Pow((-maxVelocity.x), 2) / ((deceleration) * 2)) * Time.deltaTime;

                if (movement >= walkDistance - displacement)
                {
                    velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);

                    if ((velocity.x * side) <= 0)
                    {
                        decelerating = false;
                        movement = 0;
                        pathStep += 1;
                    }
                }

                else
                {
                    Walk(path[pathStep]);
                }
            }

            else if (egoMap.path[pathStep] == "up")
            {
                float displacement = (Mathf.Pow((-maxVelocity.y), 2) / ((deceleration) * 2)) * Time.deltaTime;

                if (movement >= (walkDistance) - displacement)
                {
                    velocity.y = Mathf.MoveTowards(velocity.y, 0, deceleration * Time.deltaTime);

                    if (velocity.y <= 0)
                    {
                        decelerating = false;
                        movement = 0;
                        pathStep += 1;
                    }
                }

                else
                {
                    Walk(path[pathStep]);
                }
            }
        }


        //movement calculus
        if (egoMap.path[pathStep] == "right" | egoMap.path[pathStep] == "left")
        {
            movement = Mathf.Abs(transform.position.x - initialPosit.x);
        }

        if (egoMap.path[pathStep] == "up")
        {
            movement = Mathf.Abs(transform.position.y - initialPosit.y);
        }

        

        //check if movement is enough
        if (movement >= walkDistance)
        {
            if (egoMap.path[pathStep + 1] != egoMap.path[pathStep])
            {
                decelerating = true;
            }

            else if (egoMap.path[pathStep + 1] == egoMap.path[pathStep])
            {
                movement = 0;
                pathStep += 1;
            }
        }
    }

    /// <summary>
    /// Attacks the enemy indicated
    /// </summary>
    /// <param name="enemy">The target</param>
    void Attack(GameObject enemy)
    {
        Vector3 enemyPosit = enemy.transform.position;
        Instantiate(shot, transform.position, transform.rotation);
        shot.GetComponent<Rigidbody2D>().AddForce(enemyPosit);
    }

    #endregion
    //========================

    //RUNNING
    //========================
    #region

    //Start
    void Start()
    {
        initialPosit = transform.position;
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

                Attack(enemy);

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
