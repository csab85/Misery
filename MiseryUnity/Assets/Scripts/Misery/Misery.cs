using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misery : MonoBehaviour
{
    //IMPORTS
    //========================
    #region

    //components
    public MainCamera cam;
    Animator animator;

    #endregion
    //========================


    //STATS AND VALUES
    //========================
    #region

    //Status
    public string state;
    public float acceleration;
    public float deceleration;
    public Vector3 maxVelocity;
    public Vector3 velocity;

    //Function progression
    public bool talking = false; //defines if Misery can move and if city colliders will be up
    public bool invading = false;

    //History progression
    public float progression = 0;
    public int defeatedGhosts;

    //Battle
    public int battleLvl;
    public Color enemyColor;

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

            //animation
            animator.SetBool("Walking", true);
            animator.SetBool("Idle", false);

            if (Input.GetAxis("Horizontal") > 0)
            {
                animator.SetFloat("DirectX", 1);
            }

            if (Input.GetAxis("Horizontal") < 0)
            {
                animator.SetFloat("DirectX", -1);
            }
        }

        if (!Input.GetButton("Horizontal"))
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);

            //animation
            if (Input.GetButton("Vertical"))
            {
                animator.SetFloat("DirectX", 0);
            }
        }

        if (Input.GetButton("Vertical"))
        {
            velocity.y = Mathf.MoveTowards(velocity.y, (maxVelocity.y * side.y), acceleration * Time.deltaTime);

            //animation
            animator.SetBool("Walking", true);
            animator.SetBool("Idle", false);

            if (Input.GetAxis("Vertical") > 0)
            {
                animator.SetFloat("DirectY", 1);
            }

            if (Input.GetAxis("Vertical") < 0)
            {
                animator.SetFloat("DirectY", -1);
            }
        }

        if (!Input.GetButton("Vertical"))
        {
            velocity.y = Mathf.MoveTowards(velocity.y, 0, deceleration * Time.deltaTime);
            
            //animation
            if (Input.GetButton("Horizontal"))
            {
                animator.SetFloat("DirectY", 0);
            }
        }

        if (!Input.GetButton("Vertical") && !Input.GetButton("Horizontal"))
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Walking", false);
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
        animator = GetComponent<Animator>();
    }

    // Update
    void Update()
    {
        switch (state)
        {
            case  "walking":
                #region

                if (!talking && !invading)
                {
                    Walk();
                }

                break;

                #endregion
        }
    }

    #endregion
    //========================
}
