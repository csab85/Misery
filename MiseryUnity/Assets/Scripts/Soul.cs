using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    //STATS
    //========================
    public string[] states = {};
    public int state;

    public List<string> moods = new List<string> { "hapi", "OoO", "sad", "poker", "roblox"};
    public int mood;
    int lastMood;

    public float maxAlpha;
    Color color; //this will be set on the function that chooses archetype (and color)

    public float speed;
    public Vector3 velocity;
    public Vector3 maxVelocity;
    public float acceleration;
    //========================

    //FUNCTIONS
    //========================

    /// <summary>
    /// Changes the face of the soul
    /// </summary>
    /// <param name="mood">The mood the soul will be in (their face)</param>
    void Change_Face(string newMood)
    {
        transform.GetChild(lastMood).gameObject.SetActive(false);//deactivate current face

        mood = moods.IndexOf(newMood);//get new face
        lastMood = mood;//update last mood

        transform.GetChild(mood).gameObject.SetActive(true);//activate new face
    }

    /// <summary>
    /// Makes the soul go invisible or visible
    /// </summary>
    /// <param name="invisibling">defines if the soul will get invisible (true) or visible (false)</param>
    /// <param name="invisilationRate">how much alpha the soul earns/loses per cycle</param>
    void Invisilate(float invisilationRate, bool invisibling = true)
    {
        float alpha = transform.GetComponent<SpriteRenderer>().color.a;

        int i = 0;

        if (invisibling == true)
        {
            if (alpha <= 0)
            {
                return;
            }

            i = -1;
            //transform.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, maxAlpha + 0.1f);
        }

        if (invisibling == false)
        {
            if (alpha >= maxAlpha)
            {
                return;
            }

            i = 1;
        }

        alpha += invisilationRate * i * 0.001f;

        transform.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, alpha);
    }

    void Walk(bool leftRight = true)
    {
        if (leftRight)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            transform.GetComponent<SpriteRenderer>().flipX = true;
            transform.GetChild(mood).gameObject.transform.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (leftRight == false)
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
            transform.GetComponent<SpriteRenderer>().flipX = false;
            transform.GetChild(mood).gameObject.transform.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    //========================

    // Start is called before the first frame update
    void Start()
    {
        Change_Face(moods[mood]);
    }

    // Update is called once per frame
    void Update()
    {
        Invisilate(0.5f, false);
        Walk();
    }
}
