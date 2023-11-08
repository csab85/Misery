using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulSpawner: MonoBehaviour
{
    //IMPORTS
    //========================
    #region

    [SerializeField]
    GameObject soul;

    #endregion
    //========================


    //STATS AND VALUES
    //========================
    #region

    [SerializeField]
    int minY;
    [SerializeField]
    int maxY;

    [SerializeField]
    int cooldownTime;

    int direction = 1;

    //Functions
    //spawn
    bool cooldown = false;

    #endregion
    //========================


    //FUNCTIONS
    //========================
    #region

    IEnumerator Spawn(int time)
    {
        Instantiate(soul, transform.position, Quaternion.identity);

        cooldown = true;
        yield return new WaitForSecondsRealtime(time);
        cooldown = false;
    }

    #endregion
    //========================


    //RUNNING
    //========================
    #region

    //Start
    void Start()
    {

    }

    //Update
    void Update()
    {
        //movement up and down
        if (transform.position.y < minY | transform.position.y > maxY)
        {
            direction *= -1;
        }

        transform.position += new Vector3(0, direction * Time.deltaTime, 0);

        //spawn souls
        if (!cooldown)
        {
            StartCoroutine(Spawn(cooldownTime));
        }
    }

    #endregion
    //========================


}