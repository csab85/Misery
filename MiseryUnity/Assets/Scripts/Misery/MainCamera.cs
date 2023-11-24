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
    [SerializeField] SpriteRenderer fadeRectRenderer;

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

    float cameraX = 0;
    float cameraY = 0;

    //cam defining vars (defines the camera behaviour)
    public bool following = true;

    float fadeAlpha = 0;

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
        cameraX = Mathf.MoveTowards(cameraX, (misery.transform.position.x - miseryScript.velocity.x * camDelay), (camTravelSpeed * Time.deltaTime));
        cameraY = Mathf.MoveTowards(cameraY, (misery.transform.position.y - miseryScript.velocity.y * camDelay), (camTravelSpeed * Time.deltaTime));

        transform.position = new Vector3(cameraX, cameraY, -10);

        //arrange zoom
        if (cam.orthographicSize != 5)
        {
            cam.orthographicSize = Mathf.MoveTowards(cam.orthographicSize, 5, camZoomSpeed * Time.deltaTime);
        }
    }

    /// <summary>
    /// Makes the camera stay at the specified position and zoom
    /// </summary>
    void CameraStay()
    {
        //adjust postion
        cameraX = Mathf.MoveTowards(cameraX, camPosition.x, camTravelSpeed);
        cameraY = Mathf.MoveTowards(cameraY, camPosition.y, camTravelSpeed);

        transform.position = new Vector3(cameraX, cameraY, -10);

        //adjust zoom
        if (cam.orthographicSize != camSize)
        {
            cam.orthographicSize = Mathf.MoveTowards(cam.orthographicSize, camSize, camZoomSpeed * Time.deltaTime);
        }
    }

    /// <summary>
    /// Fades or unfades the camera to black
    /// </summary>
    /// <param name="fadeSpeed">How quick will the camera fade (if positive) or unfade (if negative)</param>
    public void Fade(float fadeSpeed)
    {
        int aimAlpha;

        if (fadeSpeed > 0)
        {
            aimAlpha = 255;
        }

        else
        {
            aimAlpha = 0;
        }

        fadeAlpha = Mathf.MoveTowards(fadeAlpha, aimAlpha, fadeSpeed * Time.deltaTime);

        fadeRectRenderer.color = new Color(0, 0, 0, fadeAlpha);
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
