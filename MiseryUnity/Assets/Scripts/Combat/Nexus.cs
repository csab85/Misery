using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nexus : MonoBehaviour
{
    //IMPORTS
    //========================
    #region

    [SerializeField] EgoMap egoMapScript;
    [SerializeField] Misery miseryScript;

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

    void WinInvasion()
    {
        foreach (GameObject unit in egoMapScript.activeUnits)
        {
            Destroy(unit);
        }

        miseryScript.defeatedGhosts += 1;
        miseryScript.occupied = false;
        Destroy(GameObject.Find("Base Invasion(Clone)"));
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

        miseryScript = GameObject.Find("Misery").GetComponent<Misery>();
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
            GetComponent<Animator>().SetBool("exploding", true);
        }
    }

    #endregion
    //========================


}
