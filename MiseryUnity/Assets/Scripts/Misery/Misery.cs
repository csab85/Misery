using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misery : MonoBehaviour
{
    //==============================================================================================STATS===================================================================================================================
    public string state;
    public float speed;
    public Vector3 velocity;
    public Vector3 maxVelocity;
    public float acceleration;


    //===============================================================================FUNCTIONS==============================================================================================================================

    //Movement--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    IEnumerator Walk()
    {
        if(Input.GetAxis("Horizontal") != 0)
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

        yield return new WaitForSecondsRealtime(0);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Walk());
    }
}
