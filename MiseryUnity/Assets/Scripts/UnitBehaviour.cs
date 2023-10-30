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
    GameObject enemy;

    #endregion
    //========================


    //STATS AND VALUES
    //========================
    #region

    //Stats
    public int health;
    public int defense;
    public int damage;
    public int attackSpeed; //defines the projectile speed, since the faster it hits the target, the faster it is shot again

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
    bool oneTimeSetup = false;
    int readDirection = 0; //defines if it'll read the list normally or inverted
    int pathStep = 0;
    float movement = 0;
    bool decelerating = false;
    Vector3 initialPosit;

    //State (walking, attacking)
    public string state = "walking";

    //Storages
    int none = 0;
    int right = 1;
    int left = -1;
    int up = 2;
    int down = -2;

    #endregion
    //========================


    //FUNCTIONS
    //========================
    #region

    /// <summary>
    /// Moves towards direction given
    /// </summary>
    /// <param name="direction">The direction to move (if its none it'll slowly stop moving)</param>
    void Walk(int direction)
    {

        if (direction == right | direction == up)
        {
            side = 1;
        }

        if (direction == left)
        {
            side = -1;
        }

        //get input
        if (direction == right | direction == left)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, (maxVelocity.x * side), acceleration * Time.deltaTime);
        }

        if (direction == up | direction == down)
        {
            velocity.y = Mathf.MoveTowards(velocity.y, (maxVelocity.y * side), acceleration * Time.deltaTime);
        }
        
        if (direction == none)
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
    void ReadPath(List<int> path)
    {
        //onetime
        if (!oneTimeSetup)
        {
            if (tag == "Ground Ally" | tag == "Air Ally")
            {
                pathStep = 0;
                readDirection = 1;
            }

            if (tag == "Ground Enemy" | tag == "Air Enemy")
            {
                pathStep = path.Count - 1;
                print(path[pathStep]);
                readDirection = -1;
            }

            oneTimeSetup = true;
        }

        //setup
        if (movement == 0)
        {
            initialPosit = transform.position;
        }


        //walk func
        if (!decelerating)
        {
            Walk((path[pathStep] * readDirection));
            print(tag + (path[pathStep] * readDirection));
        }


        //decelerate
        if (decelerating)
        {
            if (egoMap.path[pathStep] == right | egoMap.path[pathStep] == left)
            {
                float displacement = (Mathf.Pow((-maxVelocity.x), 2) / ((deceleration) * 2)) * Time.deltaTime;

                if (movement >= walkDistance - displacement)
                {
                    velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);

                    if ((velocity.x * side) <= 0)
                    {
                        decelerating = false;
                        movement = 0;
                        pathStep += readDirection;
                    }
                }

                else
                {
                    Walk((path[pathStep] * readDirection));
                }
            }

            else if (egoMap.path[pathStep] == up)
            {
                float displacement = (Mathf.Pow((-maxVelocity.y), 2) / ((deceleration) * 2)) * Time.deltaTime;

                if (movement >= (walkDistance) - displacement)
                {
                    velocity.y = Mathf.MoveTowards(velocity.y, 0, deceleration * Time.deltaTime);

                    if (velocity.y <= 0)
                    {
                        decelerating = false;
                        movement = 0;
                        pathStep += readDirection;
                    }
                }

                else
                {
                    Walk(path[pathStep]);
                }
            }
        }


        //movement calculus
        if (egoMap.path[pathStep] == right | egoMap.path[pathStep] == left)
        {
            movement = Mathf.Abs(transform.position.x - initialPosit.x);
        }

        if (egoMap.path[pathStep] == up | egoMap.path[pathStep] == down)
        {
            movement = Mathf.Abs(transform.position.y - initialPosit.y);
        }

        

        //check if movement is enough
        if (movement >= walkDistance)
        {
            if (egoMap.path[pathStep + readDirection] != egoMap.path[pathStep])
            {
                decelerating = true;
            }

            else if (egoMap.path[pathStep + readDirection] == egoMap.path[pathStep])
            {
                movement = 0;
                pathStep += readDirection;
            }
        }
    }

    /// <summary>
    /// Attacks the enemy indicated
    /// </summary>
    /// <param name="enemy">The target</param>
    void Attack(GameObject enemy)
    {
        Vector3 direction = enemy.transform.position - transform.position;
        shot.GetComponent<Rigidbody2D>().AddForce(direction);
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

                state = "waiting";

                if (enemy.tag == "Dead")
                {
                    state = "walking";
                }

                break;

            #endregion

            case "waiting":
                #region

                if (shot.transform.position == new Vector3(0, 0, 1))
                {
                    state = "attacking";
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
