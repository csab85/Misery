using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    //IMPORTS
    //========================
    #region

    //Game Objects
    GameObject player;

    //Components
    Camera cam;

    #endregion
    //========================


    //STATS AND VALUES
    //========================
    #region

    //camera settings
    public float camDelay;
    public float camTravelSpeed;
    public float zoomSpeed;

    //cam defining vars (defines the camera behaviour)
    bool following = true;
    float camSize;
    Vector2 camPosition;

    //flow vars (defines behaviours values)
    public string lastRooftop;
    public string actualRooftop;
    bool changed = true;
    public string place = "Outside";

    public bool changing = false; //call change ambient function on updadte

    #endregion
    //========================


    //FUNCTIONS
    //========================
    #region

    /// <summary>
    /// Makes the rooftop go invisible or visible
    /// </summary>
    /// <param name="rooftopName">the rooftop that is going to fade/unfade (gotta be the game object's name in the editor)</param>
    /// <param name="fadingRate">how much alpha the rooftop earns/loses per cycle</param>
    bool Fade(string rooftopName, float fadingRate)
    {
        if (rooftopName != "Outside")
        {
            GameObject rooftop = GameObject.Find(rooftopName);

            float alpha = rooftop.GetComponent<SpriteRenderer>().color.a;

            if (fadingRate > 0)
            {
                if (alpha <= 0)
                {
                    return true;
                }
            }

            if (fadingRate < 0)
            {
                if (alpha >= 1)
                {
                    return true;
                }
            }

            alpha -= fadingRate * 0.001f;

            Color rooftopColor = rooftop.transform.GetComponent<SpriteRenderer>().color;

            rooftop.transform.GetComponent<SpriteRenderer>().color = new Color(rooftopColor.r, rooftopColor.g, rooftopColor.b, alpha);
        }

        return false;
    }

    /// <summary>
    /// Follows the player with a delayed repositioning
    /// </summary>
    void CameraFollow()
{
    float cameraX = player.transform.position.x - Input.GetAxis("Horizontal") * camDelay;
    float cameraY = player.transform.position.y - Input.GetAxis("Vertical") * camDelay;

    transform.position = new Vector3(cameraX, cameraY, -10);
}

    /// <summary>
    /// Switches camera to following/fixed, rooftops to visible/invisible and zoom to zoomed in/zoomed out depending on the place Misery is
    /// </summary>
    void ChangeAmbient()
    {
        if (changed)
        {
            lastRooftop = actualRooftop;

            //outside
            if (place == "Outside")
            {
                following = true;
                camSize = 5;
                actualRooftop = "Outside";
            }

            //experimental place
            if (place == "House")
            {
                following = false;
                camPosition = new Vector2(-7, 0.7f);
                camSize = 2.5f;
                actualRooftop = "House Rooftop";
            }

            changed = false;
        }

        if (changed == false)
        {
            //cam size
            #region
            bool correctSize = false;

            if (cam.orthographicSize < camSize)
            {
                cam.orthographicSize += zoomSpeed * Time.deltaTime;
            }

            if (cam.orthographicSize > camSize)
            {
                cam.orthographicSize -= zoomSpeed * Time.deltaTime;
            }

            //check size
            if (cam.orthographicSize > (camSize - 0.1f) && cam.orthographicSize < (camSize + 0.1f))
            {
                correctSize = true;
            }
            #endregion

            //cam position
            #region
            bool correctPositX = false;
            bool correctPositY = false;

            if(transform.position.x < camPosition.x)
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

            //check posit
            if (transform.position.x > (camPosition.x - 0.1f) && transform.position.x < (camPosition.x + 0.1f))
            {
                correctPositX = true;
            }

            if (transform.position.y > (camPosition.y - 0.1f) && transform.position.y < (camPosition.y + 0.1f))
            {
                correctPositY = true;
            }
            #endregion

            //rooftop visibility
            #region

            bool correctFadedRooftop = Fade(actualRooftop, 3);
            bool correctUnfadedRooftop = Fade(lastRooftop, -3);

            #endregion

            //check all
            if (correctSize && correctPositX && correctPositY && correctFadedRooftop && correctUnfadedRooftop)
            {
                changed = true;
                changing = false;
            }
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
        player = GameObject.Find("Misery");
        cam = gameObject.GetComponent<Camera>();
    }

    // Update
    void Update()
    {
        if (following)
        {
            CameraFollow();
        }

        if (changing)
        {
            ChangeAmbient();
        }
    }

    #endregion
    //========================


}
