using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public float health;
    float maxHealth;
    public int defense;

    //Function progression

    //damage
    bool damaging = false;
    public float damageTaken = 0;
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

        health -= damageTaken;
        damageTaken = 0;

        GetComponent<SpriteRenderer>().color = new Color(200, 0, 0);
        yield return new WaitForSecondsRealtime(0.3f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);

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
            if (name != "Gates")
            {
                Destroy(gameObject);
            }
            else
            {
                SceneManager.UnloadSceneAsync("BaseInvasion");
            }
        }
    }

    #endregion
    //========================


}
