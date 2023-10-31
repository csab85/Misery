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
    public Shot shotScript;
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
    Vector3 startingPosit;

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

        if (direction == left | direction == down)
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

                startingPosit = egoMap.pathPositions[0]; 
            }

            if (tag == "Ground Enemy" | tag == "Air Enemy")
            {
                pathStep = path.Count - 2;
                readDirection = -1;

                startingPosit = egoMap.pathPositions[path.Count - 1];
            }

            //position correction
            startingPosit.x += 0.5f;
            startingPosit.y += 0.5f;

            print(startingPosit);
            transform.position = startingPosit;

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
        }


        //decelerate
        if (decelerating)
        {
            if (path[pathStep] == right | path[pathStep] == left)
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

            else if (path[pathStep] == up | path[pathStep] == down)
            {
                float displacement = (Mathf.Pow((-maxVelocity.y), 2) / ((deceleration) * 2)) * Time.deltaTime;

                if (movement >= (walkDistance) - displacement)
                {
                    velocity.y = Mathf.MoveTowards(velocity.y, 0, deceleration * Time.deltaTime);

                    if (velocity.y * side <= 0)
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
        if (path[pathStep] == right | egoMap.path[pathStep] == left)
        {
            movement = Mathf.Abs(transform.position.x - initialPosit.x);
        }

        if (path[pathStep] == up | path[pathStep] == down)
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
        shotScript.state = "moving";

        Vector3 direction = enemy.transform.position - transform.position;

        shot.GetComponent<Rigidbody2D>().AddForce(Vector3.Scale(direction, new Vector3(attackSpeed, attackSpeed, 0)));
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
        if (health <= 0)
        {
            tag = "Dead";
            gameObject.SetActive(false);
        }

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
                    break;
                }

                Attack(enemy);

                state = "waiting";

                break;

            #endregion

            case "waiting":
                #region

                if (shotScript.state == "static")
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
        if (tag == "Ground Ally" | tag == "Air Ally")
        {
            if (collision.tag == "Air Enemy" | collision.tag == "Ground Enemy")
            {
                enemy = collision.gameObject;
                state = "attacking";
            }
        }

        if (tag == "Ground Enemy" | tag == "Air Enemy")
        {
            if (collision.tag == "Air Ally" | collision.tag == "Ground Ally")
            {
                enemy = collision.gameObject;
                state = "attacking";
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tag == "Ground Ally" | tag == "Air Ally")
        {
            if (collision.tag == "Air Enemy Shot" | collision.tag == "Ground Enemy Shot")
            {
                if (Mathf.Abs(collision.transform.position.x - transform.position.x) < 1) //see if it collided with hitbox or range (maybe if its smaller than range?)
                {
                    health -= 1;
                }
            }
        }

        if (tag == "Ground Enemy" | tag == "Air Enemy")
        {
            if (collision.tag == "Air Ally Shot" | collision.tag == "Ground Ally Shot")
            {
                if (Mathf.Abs(collision.transform.position.x - transform.position.x) < 1) //see if it collided with hitbox or range (maybe if its smaller than range?)
                {
                    health -= 1;
                }
            }
        }
    }

    #endregion
    //========================


}
