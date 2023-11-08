using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    //IMPORTS
    //========================
    #region

    //Game Objects
    GameObject misery;

    //Components
    Camera cam;

    //Scripts
    public Misery miseryScript;

    #endregion
    //========================


    //STATS AND VALUES
    //========================
    #region

    //camera settings
    public Vector3 camPosition;
    public float camSize;
    public float camDelay;
    public float camTravelSpeed;
    public float camZoomSpeed;

    //cam defining vars (defines the camera behaviour)
    public bool following = true;

    #endregion
    //========================


    //FUNCTIONS
    //========================
    #region

    /// <summary>
    /// Follows the player with a delayed repositioning
    /// </summary>
    void CameraFollow()
{
        float cameraX = misery.transform.position.x - miseryScript.velocity.x * camDelay;
        float cameraY = misery.transform.position.y - miseryScript.velocity.y * camDelay;

        if (miseryScript.velocity.x != 0 && miseryScript.velocity.y != 0)
        {
            transform.position = new Vector3(cameraX, cameraY, -10);
        }

        //arrange position
        else
        {
            if (transform.position.x < cameraX)
            {
                transform.position += new Vector3(camTravelSpeed, 0, 0) * Time.deltaTime;
            }

            if (transform.position.x > cameraX)
            {
                transform.position -= new Vector3(camTravelSpeed, 0, 0) * Time.deltaTime;
            }

            if (transform.position.y < cameraY)
            {
                transform.position += new Vector3(0, camTravelSpeed, 0) * Time.deltaTime;
            }

            if (transform.position.y > cameraY)
            {
                transform.position -= new Vector3(0, camTravelSpeed, 0) * Time.deltaTime;
            }
        }

        //arrange zoom
        if (cam.orthographicSize < 5)
        {
            cam.orthographicSize += 1 * camZoomSpeed * Time.deltaTime;
        }

        if (cam.orthographicSize > 5)
        {
            cam.orthographicSize -= 1 * camZoomSpeed * Time.deltaTime;
        }
    }

    void CameraStay()
    {
        //adjust postion
        if (transform.position.x < camPosition.x)
        {
            transform.position += new Vector3(camTravelSpeed, 0, 0) * Time.deltaTime;
        }

        if (transform.position.x > camPosition.x)
        {
            transform.position -= new Vector3(camTravelSpeed, 0, 0) * Time.deltaTime;
        }

        if (transform.position.y < camPosition.y)
        {
            transform.position += new Vector3(0, camTravelSpeed, 0) * Time.deltaTime;
        }

        if (transform.position.y > camPosition.y)
        {
            transform.position -= new Vector3(0, camTravelSpeed, 0) * Time.deltaTime;
        }

        //adjust zoom
        if (cam.orthographicSize < camSize)
        {
            cam.orthographicSize += 1 * camZoomSpeed * Time.deltaTime;
        }

        if (cam.orthographicSize > camSize)
        {
            cam.orthographicSize -= 1 * camZoomSpeed * Time.deltaTime;
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
        misery = GameObject.Find("Misery");
        cam = gameObject.GetComponent<Camera>();
    }

    // Update
    void Update()
    {
        if (following)
        {
            CameraFollow();
        }

        if (!following)
        {
            CameraStay();
        }
    }

    #endregion
    //========================


}
