using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    //IMPORTS
    //========================
    #region

    Misery miseryScript;

    #endregion
    //========================

    //STATS
    //========================
    #region

    //Movement
    public float speed;
    Vector3 velocity;
    public Vector3 maxVelocity;
    public float acceleration;
    public float walkRange;
    float startingX;
    public float movement;

    //State
    public string[] states = {"fading", "walking", "unfading"};
    public string state = "unfading";
    int stateValue = 0;

    //Mood
    public List<string> moods = new List<string> { "hapi", "OoO", "sad", "poker", "roblox"};
    public string mood;
    int moodValue;
    int lastMoodValue;

    //Color
    public float maxAlpha;
    Color color; //this will be set on the function that chooses archetype (and color)

    //Gambiarras
    bool leftStreet = true;
    int directionValue = 1;

    #endregion
    //========================


    //FUNCTIONS
    //========================
    #region

    /// <summary>
    /// Changes the face of the soul
    /// </summary>
    /// <param name="mood">The mood the soul will be in (their face)</param>
    void ChangeFace(string newMood)
    {
        transform.GetChild(lastMoodValue).gameObject.SetActive(false);//deactivate current face

        moodValue = Random.Range(0, 4);

        mood = moods[moodValue];//get new face
        lastMoodValue = moodValue;//update last mood

        transform.GetChild(moodValue).gameObject.SetActive(true);//activate new face
    }

    /// <summary>
    /// Makes the soul go invisible or visible
    /// </summary>
    /// <param name="fading">defines if the soul will get invisible (true) or visible (false)</param>
    /// <param name="fadingRate">how much alpha the soul earns/loses per cycle</param>
    bool Fade(float fadingRate)
    {
        float alpha = transform.GetComponent<SpriteRenderer>().color.a;

        if (fadingRate > 0)
        {
            if (alpha <= 0)
            {
                return true;
            }
        }

        if (fadingRate < 0)
        {
            if (alpha >= maxAlpha)
            {
                return true;
            }
        }

        alpha -= fadingRate * 0.001f;

        transform.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, alpha);

        return false;
    }

    /// <summary>
    /// Makes the soul move left or right, and sets the mirror accordingly
    /// </summary>
    /// <param name="leftRight">If true makes the soul go from left to right, if not the soul goes right to left</param>
    /// <returns></returns>
    bool Walk(bool leftRight = true)
    {
        if (leftRight)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            movement += speed * Time.deltaTime;
            transform.GetComponent<SpriteRenderer>().flipX = true;
            transform.GetChild(moodValue).gameObject.transform.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (leftRight == false)
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
            movement -= speed * Time.deltaTime;
            transform.GetComponent<SpriteRenderer>().flipX = false;
            transform.GetChild(moodValue).gameObject.transform.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (movement >= walkRange)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Chooses the soul stats and color
    /// </summary>
    void ChooseColor()
    {
        color = new Color(Random.value, Random.value, Random.value, 0);
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }

    #endregion
    //========================


    //RUNNING
    //========================
    #region

    //Start
    void Start()
    {
        miseryScript = GameObject.Find("Misery").GetComponent<Misery>();

        ChangeFace(mood);
        ChooseColor();

        if (transform.position.x > 0)//if it aint this then leftRight is already set right
        {
            leftStreet = false;
        }

        startingX = transform.position.x;
    }

    //Úpdate
    void Update()
    {
        switch (state)
        {
            case "unfading":
                #region

                bool finishedUnfading = false;

                finishedUnfading = Fade(-1);
                Walk(leftStreet);
                
                if (finishedUnfading)
                {
                    stateValue += 1;
                    state = states[stateValue];
                }

                break;

                #endregion

            case "walking":
                #region

                bool finishedWalking = false;
                finishedWalking = Walk(leftStreet);
                
                if (finishedWalking)
                {
                    state = "fading";
                }

                break;

                #endregion

            case "fading":
                #region

                bool finishedFading = false;

                Walk(leftStreet);
                finishedFading = Fade(4);

                if (finishedFading)
                {
                    Destroy(gameObject);
                }

                break;

                #endregion
        }

        if (miseryScript.invading)
        {
            speed = 2;
        }
    }

    #endregion
}
