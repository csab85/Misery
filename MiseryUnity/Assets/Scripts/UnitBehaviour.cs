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
    public Vector3 velocity;
    public Vector3 maxVelocity;
    public float acceleration;
    public float deceleration;

    //Function progresssion
    //walk
    int side = 0;

    //move
    int movementDirection = 0;
    bool oneTimeSetup = false;
    bool decelerating = false;

    //State (walking, attacking)
    public string state = "walking";

    //Storages
    int none = 0;
    int up = 1;
    int down = -1;
    int right = 2;
    int left = -2;

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
    /// Makes the object move towards it objective and dodge obstacles
    /// </summary>
    /// <param></param>
    void Move()
    {
        //onetime
        if (!oneTimeSetup)
        {
            if (tag == "Ground Ally" | tag == "Air Ally")
            {
                movementDirection = up;
            }

            if (tag == "Ground Enemy" | tag == "Air Enemy")
            {
                movementDirection = down;
            }

            oneTimeSetup = true;
        }

        //decelerate
        if (decelerating)
        {
            if (movementDirection == right | movementDirection == left)
            {
                velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration);
            }

            if (movementDirection == up | movementDirection == down)
            {
                velocity.y = Mathf.MoveTowards(velocity.y, 0, deceleration);
            }
        }

        Walk(movementDirection);
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
        if (tag == "Ground Ally" | tag == "Air Ally")
        {
            movementDirection = up;
        }

        if (tag == "Ground Enemy" | tag == "Air Enemy")
        {
            movementDirection = down;
        }
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
                
                Walk(movementDirection);

                break;

            #endregion

            case "attacking":
                #region

                if (enemy.tag == "Dead")
                {
                    state = "walking";
                    break;
                }

                if (velocity.x == 0 && velocity.y == 0)
                {
                    Attack(enemy);
                    state = "waiting";
                    break;
                }

                else
                {
                    Walk(none);
                }

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
