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
    public float camSpeed;
    public float zoomSpeed;

    //cam defining vars (defines the camera behaviour)
    bool following = true;
    float camSize;
    Vector2 camPosition;

    //flow vars (defines behaviours values)
    string lastRooftop;
    string actualRooftop;
    bool changed = true;
    string place = "outside";

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
        GameObject rooftop = GameObject.Find(rooftopName);

        float alpha = rooftop.GetComponent<SpriteRenderer>().color.a;

        if (fadingRate < 0)
        {
            if (alpha <= 0)
            {
                return true;
            }
        }

        if (fadingRate > 0)
        {
            if (alpha >= 1)
            {
                return true;
            }
        }

        alpha += fadingRate * 0.001f;

        Color rooftopColor = rooftop.transform.GetComponent<SpriteRenderer>().color;

        rooftop.transform.GetComponent<SpriteRenderer>().color = new Color(rooftopColor.r, rooftopColor.g, rooftopColor.b, alpha);

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
            //outside
            if (place == "outside")
            {
                following = true;
                camSize = 5;
                actualRooftop = "outside";
            }

            //experimental place
            if (place == "experiment")
            {
                following = false;
                camSize = 3;
                actualRooftop = "outside";
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
                cam.orthographicSize += zoomSpeed;
            }

            if (cam.orthographicSize > camSize)
            {
                cam.orthographicSize -= zoomSpeed;
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

            if(camPosition.x < transform.position.x)
            {
                transform.position += new Vector3(camSpeed, 0, 0) * Time.deltaTime;
            }

            if (camPosition.x > transform.position.x)
            {
                transform.position -= new Vector3(camSpeed, 0, 0) * Time.deltaTime;
            }

            if (camPosition.y < transform.position.y)
            {
                transform.position += new Vector3(0, camSpeed, 0) * Time.deltaTime;
            }

            if (camPosition.y > transform.position.y)
            {
                transform.position -= new Vector3(0, camSpeed, 0) * Time.deltaTime;
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

            bool correctFadedRooftop = Fade(actualRooftop, 1);
            bool correctUnfadedRooftop = Fade(lastRooftop, -1);

            #endregion

            //check all
            if (correctSize && correctPositX && correctPositY && correctFadedRooftop && correctUnfadedRooftop)
            {
                changed = true;
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
    }

    //Change ambient
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }

    #endregion
    //========================


}
