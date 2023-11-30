 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnitBehaviour : MonoBehaviour
{
    //IMPORTS
    //========================
    #region

    Misery miseryScript;
    public EgoMap egoMap;
    public GameObject shot;
    public Shot shotScript;
    public UnitBehaviour self;
    public GameObject enemy;

    #endregion
    //========================


    //STATS AND VALUES
    //========================
    #region

    //Stats
    public string type;
    public float health;
    public float cost;
    public float damage;
    public float aoe;
    public float attackSpeed; //defines the projectile speed, since the faster it hits the target, the faster it is shot 
    public float range;

    public float damageTaken = 0;

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

    //attack
    public Vector3 direction;
    bool directioned = false;

    //State (walking, attacking)
    public string state = "walking";

    //Storages
    int none = 0;
    int up = 1;
    int down = -1;
    int right = 2;
    int left = -2;

    string selfTag;
    Color selfColor;

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
        if (shotScript.state == "static")
        {
            shotScript.state = "moving";
        }


        if (!directioned)
        {
            direction = (enemy.transform.position - transform.position).normalized;
            directioned = true;
        }
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
        yield return new WaitForSecondsRealtime(0.1f);
        GetComponent<SpriteRenderer>().color = selfColor;

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
        miseryScript = GameObject.Find("Misery").GetComponent<Misery>();

        if(miseryScript.battleLvl == 4)
        {
            GameObject.Find("Nexus").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("Nexus").tag = "Untagged";
        }

        //setup if it is enemy or ally
        if (tag == "Ally")
        {
            movementDirection = up;
            selfColor = new Color(1, 1, 1, 1);
        }

        if (tag == "Enemy")
        {
            movementDirection = down;

            if (miseryScript.battleLvl < 4)
            {
                selfColor = miseryScript.enemyColor;
                GetComponent<SpriteRenderer>().color = new Color(selfColor.r, selfColor.g, selfColor.b, 1);
            }
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
            if (name != "Time Boss")
            {
                tag = "Dead";
                gameObject.SetActive(false);
            }
            else
            {
                foreach (GameObject unit in egoMap.activeUnits)
                {
                    Destroy(unit);
                }

                miseryScript.invading = false;
                miseryScript.talking = false;

                GameObject.Find("Invasion Text 1").GetComponent<Fader>().progression = 2;
                GameObject.Find("Invasion Text 2").GetComponent<TextMeshProUGUI>().text = GameObject.Find("Invasion Text 1").GetComponent<Fader>().chosenStroy[1];
            }
        }

        if (tag != "Dead" && tag != "Damaged")
        {
            switch (state)
            {
                case "walking":
                    #region

                    GetComponent<Animator>().SetBool("shooting", false);
                    GetComponent<Animator>().SetBool("walking", true);

                    Walk(movementDirection);

                    break;

                #endregion

                case "attacking":
                    #region

                    GetComponent<Animator>().SetBool("shooting", true);
                    GetComponent<Animator>().SetBool("walking", false);

                    if (enemy.tag == "Dead")
                    {
                        directioned = false;
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

                    GetComponent<Animator>().SetBool("shooting", false);
                    GetComponent<Animator>().SetBool("walking", false);

                    if (shotScript.state == "static")
                    {
                        directioned = false;
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
        if (targets.Contains(collision.tag) && state != "waiting")
        {
            enemy = collision.gameObject;
            state = "attacking";
        }
    }

    #endregion
    //========================


}
