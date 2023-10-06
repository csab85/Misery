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
    public float speed;
    public Vector3 velocity;
    public Vector3 maxVelocity;
    public float acceleration;

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
        if (Input.GetAxis("Horizontal") != 0)
        {
            velocity.x = Input.GetAxis("Horizontal") * acceleration;
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            velocity.y = Input.GetAxis("Vertical") * acceleration;
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
                cam.place = "outside";
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
