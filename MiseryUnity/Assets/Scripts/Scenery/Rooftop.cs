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
    [SerializeField] SpriteRenderer spriteRenderer;

    #endregion
    //========================


    //STATS AND VALUES
    //========================
    #region

    [SerializeField] Vector3 cameraPosit;
    [SerializeField] float cameraSize;

    //Functions
    bool fade = false;
    public float alpha;

    #endregion
    //========================


    //FUNCTIONS
    //========================
    #region

    /// <summary>
    /// Fades the rooftop (if positive) or unfades it (if it is negative)
    /// </summary>
    /// <param name="fadingRate">How much alpha the rooftop loses/gains per loop</param>
    IEnumerator Fade(float fadingRate)
    {
        alpha = spriteRenderer.color.a;

        alpha -= fadingRate * Time.deltaTime;

        spriteRenderer.color = new Color(1, 1, 1, alpha);

        yield return new WaitForSecondsRealtime(0.05f);
    }

    #endregion
    //========================


    //RUNNING
    //========================
    #region

    //Start
    void Start()
    {
        Mathf.Clamp(alpha, 0, 1);
    }

    //Update
    void Update()
    {
        if (fade)
        {
            if (alpha >= 0)
            {
                StartCoroutine(Fade(1));
            }
        }

        if (!fade)
        {
            if (alpha <= 1)
            {
                StartCoroutine(Fade(-1));
            }
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
