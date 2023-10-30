using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    //IMPORTS
    //========================
    #region



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
    int pathStep = 0;
    float movement = 0;
    bool decelerating = false;
    Vector3 initialPosit;

    //State (walking, attacking)
    public string state = "walking";

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
        //delete ball if gets too far
    }

    //Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyGround")
        {
            transform.position = transform.parent.transform.position;
        }
    }

    #endregion
    //========================


}
