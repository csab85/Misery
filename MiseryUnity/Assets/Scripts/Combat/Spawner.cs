using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //IMPORTS
    //========================
    #region

    public GameObject[] enemiesArray;
    public GameObject enemy;

    [SerializeField] EgoMap egomapScript;
    [SerializeField] GameObject nexus;

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
        nexus.GetComponent<Animator>().SetBool("spawning", true);
        egomapScript.activeUnits.Add(Instantiate(enemy, transform.position, Quaternion.identity));
        onCoooldown = true;
        yield return new WaitForSecondsRealtime(1);
        nexus.GetComponent<Animator>().SetBool("spawning", false);
        yield return new WaitForSeconds(cooldown - 1);
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
        enemy = enemiesArray[Random.Range(0, enemiesArray.Length)];
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
