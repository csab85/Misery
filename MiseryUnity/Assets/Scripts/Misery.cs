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
    public float decelaration;
    public Vector3 maxVelocity;
    public Vector3 velocity;
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
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //get input
        if (Input.GetButton("Horizontal"))
        {
            velocity.x = Mathf.MoveTowards(velocity.x, (maxVelocity.x * direction.x), acceleration * Time.deltaTime);
        }

        if (!Input.GetButton("Horizontal"))
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, decelaration * Time.deltaTime);
        }

        if (Input.GetButton("Vertical"))
        {
            velocity.y = Mathf.MoveTowards(velocity.y, (maxVelocity.y * direction.y), acceleration * Time.deltaTime);
        }

        if (!Input.GetButton("Vertical"))
        {
            velocity.y = Mathf.MoveTowards(velocity.y, 0, decelaration * Time.deltaTime);
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
