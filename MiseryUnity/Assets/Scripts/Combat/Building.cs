using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    //IMPORTS
    //========================
    #region



    #endregion
    //========================


    //STATS AND VALUES
    //========================
    #region

    //Stats
    public int health;
    int maxHealth;
    public int defense;

    //Function progression

    //damage
    bool damaging = false;

    string selfTag;

    #endregion
    //========================


    //FUNCTIONS
    //========================
    #region

    /// <summary>
    /// Damages this unit ans turns it invulnerable for a while
    /// </summary>
    /// <returns></returns>
    IEnumerator Damage()
    {
        damaging = true;
        health -= 1;
        GetComponent<SpriteRenderer>().color = new Color(200, 0, 0);
        yield return new WaitForSecondsRealtime(0.2f);
        GetComponent<SpriteRenderer>().color = new Color(250, (health * (250 / maxHealth)), (health * (250 / maxHealth)));
        tag = selfTag;
        damaging = false;
    }

    #endregion
    //========================


    //RUNNING
    //========================
    #region

    //Start
    void Start()
    {
        selfTag = tag;
        maxHealth = health;
    }

    //Update
    void Update()
    {
        if (tag == "Damaged" && !damaging)
        {
            StartCoroutine(Damage());
        }

        if (health < 0)
        {
            Destroy(gameObject);
        }
    }

    #endregion
    //========================


}
