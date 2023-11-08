using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misery : MonoBehaviour
{
    //IMPORTS
    //========================
    #region

    public MainCamera cam;

    #endregion
    //========================


    //STATS AND VALUES
    //========================
    #region

    public string state;
    public float acceleration;
    public float deceleration;
    public Vector3 maxVelocity;
    public Vector3 velocity;

    //Function progression
    public bool moving = false; //allows player to move or not while on menu

    #endregion
    //========================


    //FUNCTIONS
    //========================
    #region

    /// <summary>
    /// Move misery accordyingly to keyboard input
    /// </summary>
    /// <returns></returns>
    void Walk()
    {
        Vector2 side = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //get input
        if (Input.GetButton("Horizontal"))
        {
            velocity.x = Mathf.MoveTowards(velocity.x, (maxVelocity.x * side.x), acceleration * Time.deltaTime);
        }

        if (!Input.GetButton("Horizontal"))
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }

        if (Input.GetButton("Vertical"))
        {
            velocity.y = Mathf.MoveTowards(velocity.y, (maxVelocity.y * side.y), acceleration * Time.deltaTime);
        }

        if (!Input.GetButton("Vertical"))
        {
            velocity.y = Mathf.MoveTowards(velocity.y, 0, deceleration * Time.deltaTime);
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

    // Update
    void Update()
    {
        Walk();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (cam.changing == false)
        {
            if (cam.place == collision.tag)
            {
                cam.place = "Outside";
            }

            else
            {
                cam.place = collision.tag;
            }
        }

        cam.changing = true;
    }

    #endregion
    //========================
}
