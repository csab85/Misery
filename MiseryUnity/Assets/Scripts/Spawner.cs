using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //IMPORTS
    //========================
    #region

    public GameObject enemy;

    #endregion
    //========================


    //STATS AND VALUES
    //========================
    #region

    public float cooldown;
    bool onCoooldown = false;

    #endregion
    //========================


    //FUNCTIONS
    //========================
    #region

    IEnumerator SpawnEnemy()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
        onCoooldown = true;
        yield return new WaitForSeconds(cooldown);
        onCoooldown = false;
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
        if (!onCoooldown)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    #endregion
    //========================


}
