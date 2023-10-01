using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    //STATS
    //========================
    
    //Movement
    public float speed;
    Vector3 velocity;
    public Vector3 maxVelocity;
    public float acceleration;
    public float walkRange;
    float movement;

    //State
    public string[] states = {"visilating", "walking", "invisilating"};
    public string state = "visilating";
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

    //========================

    //FUNCTIONS
    //========================
    /// <summary>
    /// Changes the face of the soul
    /// </summary>
    /// <param name="mood">The mood the soul will be in (their face)</param>
    void ChangeFace(string newMood)
    {
        transform.GetChild(lastMoodValue).gameObject.SetActive(false);//deactivate current face

        mood = moods[moodValue];//get new face
        lastMoodValue = moodValue;//update last mood

        transform.GetChild(moodValue).gameObject.SetActive(true);//activate new face
    }

    /// <summary>
    /// Makes the soul go invisible or visible
    /// </summary>
    /// <param name="invisibling">defines if the soul will get invisible (true) or visible (false)</param>
    /// <param name="invisilationRate">how much alpha the soul earns/loses per cycle</param>
    bool Invisilate(float invisilationRate, bool invisibling = true)
    {
        float alpha = transform.GetComponent<SpriteRenderer>().color.a;

        int i = 0;

        if (invisibling == true)
        {
            if (alpha <= 0)
            {
                return true;
            }

            i = -1;
            //transform.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, maxAlpha + 0.1f);
        }

        if (invisibling == false)
        {
            if (alpha >= maxAlpha)
            {
                return true;
            }

            i = 1;
        }

        alpha += invisilationRate * i * 0.001f;

        transform.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, alpha);

        return false;
    }

    bool Walk(bool leftRight = true)
    {
        if (leftRight)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            transform.GetComponent<SpriteRenderer>().flipX = true;
            transform.GetChild(moodValue).gameObject.transform.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (leftRight == false)
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
            transform.GetComponent<SpriteRenderer>().flipX = false;
            transform.GetChild(moodValue).gameObject.transform.GetComponent<SpriteRenderer>().flipX = false;
        }

        movement = walkRange - transform.position.x;

        if (movement <= 0)
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
    //========================


    void Start()
    {
        ChangeFace(mood);
        ChooseColor();
    }


    void Update()
    {
        switch (state)
        {
            case "visilating":

                bool finishedVisilating = false;

                if (transform.position.x > 0)//if it aint this then leftRight is already set right
                {
                    leftStreet = false;
                }

                finishedVisilating = Invisilate(0.1f, false);
                Walk(leftStreet);
                
                if (finishedVisilating)
                {
                    stateValue += 1;
                    state = states[stateValue];
                }

                break;

            case "walking":

                bool finishedWalking = false;
                finishedWalking = Walk(leftStreet);
                
                if (finishedWalking)
                {
                    state = "invisilating";
                }

                break;

            case "invisilating":

                bool finishedInvisilating = false;

                Walk(leftStreet);
                finishedInvisilating = Invisilate(0.1f);

                if (finishedInvisilating)
                {
                    Destroy(gameObject);
                }

                break;

        }
    }
}
