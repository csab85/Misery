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
    //========================

    // Start is called before the first frame update
    void Start()
    {
        Change_Face(moods[mood]);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
