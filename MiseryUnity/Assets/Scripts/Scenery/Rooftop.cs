using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooftop : MonoBehaviour
{
    //IMPORTS
    //========================
    #region

    //Scripts
    [SerializeField] MainCamera cameraScript;

    #endregion
    //========================


    //STATS AND VALUES
    //========================
    #region

    [SerializeField] Vector3 cameraPosit;
    [SerializeField] float cameraSize;

    //Functions
    bool fade = false;

    #endregion
    //========================


    //FUNCTIONS
    //========================
    #region

    /// <summary>
    /// Fades the rooftop (if positive) or unfades it (if it is negative)
    /// </summary>
    /// <param name="fadingRate">How much alpha the rooftop loses/gains per loop</param>
    void Fade(float fadingRate)
    {
        float alpha = GetComponent<SpriteRenderer>().color.a;

        alpha -= fadingRate * Time.deltaTime;

        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, alpha);
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

    //Update
    void Update()
    {
        if (fade)
        {
            Fade(1);
        }

        if (!fade)
        {
            Fade(-1);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            fade = true;
            cameraScript.following = false;
            cameraScript.camPosition = cameraPosit;
            cameraScript.camSize = cameraSize;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       if (collision.tag == "Player")
        {
            fade = false;
            cameraScript.following = true;
        } 
    }

    #endregion
    //========================


}
