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
    public UnitBehaviour self;
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
    public int aoe;
    public float attackSpeed; //defines the projectile speed, since the faster it hits the target, the faster it is shot again
    public int range;

    public int damageTaken = 0;

    //Debuffs
    bool eliteShooterDebuff = false;

    //Movement
    Vector3 velocity;
    public Vector3 maxVelocity;
    public float acceleration;
    public float deceleration;

    //Targets
    public List<string> targets;
    public bool targetAlly;
    public bool targetEnemy;
    public bool targetBuilding;

    //Function progresssion
    //walk
    int side = 0;

    //damage
    bool damaging = false;

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

    string selfTag;

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

        Vector3 direction = (enemy.transform.position - transform.position).normalized;

        shot.GetComponent<Rigidbody2D>().velocity = direction * 5;
    }

    /// <summary>
    /// Damages this unit ans turns it invulnerable for a while
    /// </summary>
    /// <returns></returns>
    IEnumerator Damage()
    {
        damaging = true; 

        if (eliteShooterDebuff)
        {
            damageTaken += 1;
        }

        health -= damageTaken;
        damageTaken = 0;

        GetComponent<SpriteRenderer>().color = new Color(200, 0, 0);
        yield return new WaitForSecondsRealtime(0.3f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);

        tag = selfTag;
        damaging = false;
    }

    #endregion
    //========================


    //RUNNING
    //========================
    #region

    //Start
    void Start()
    {
        //setup if it is enemy or ally
        if (tag == "Ally")
        {
            movementDirection = up;
        }

        if (tag == "Enemy")
        {
            movementDirection = down;
        }

        //setup targets

        if (targetAlly)
        {
            targets.Add("Ally");
        }

        if (targetEnemy)
        {
            targets.Add("Enemy");
        }

        if (targetBuilding)
        {
            targets.Add("Building");
        }

        //get self tag
        selfTag = tag;
    }

    //Update
    void Update()
    {
        if (health <= 0)
        {
            tag = "Dead";
            gameObject.SetActive(false);
        }

        if (tag != "Dead" && tag != "Damaged")
        {
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

        if (tag == "Damaged" && !damaging)
        {
            StartCoroutine(Damage());
        }
    }

    //Range trigger
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (targets.Contains(collision.tag))
        {
            enemy = collision.gameObject;
            state = "attacking";
        }
    }

    #endregion
    //========================


}
