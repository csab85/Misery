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

    Misery miseryScript;
    [SerializeField] Fader egoMapFader;
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

        if (enemy.GetComponent<UnitBehaviour>().type == "Enemy Shooter")
        {
            egomapScript.activeUnits.Add(Instantiate(enemy, transform.position + new Vector3(0.3f, 0, 0), Quaternion.identity));
            egomapScript.activeUnits.Add(Instantiate(enemy, transform.position + new Vector3(-0.3f, 0, 0), Quaternion.identity));
            egomapScript.activeUnits.Add(Instantiate(enemy, transform.position + new Vector3(0, 0.3f, 0), Quaternion.identity));
            egomapScript.activeUnits.Add(Instantiate(enemy, transform.position + new Vector3(0, -0.3f, 0), Quaternion.identity));
        }

        else
        {
            egomapScript.activeUnits.Add(Instantiate(enemy, transform.position, Quaternion.identity));
        }
        

        onCoooldown = true;
        yield return new WaitForSecondsRealtime(1);

        if (miseryScript.battleLvl != 4)
        {
            nexus.GetComponent<Animator>().SetBool("spawning", false);
        }
        
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
        miseryScript = GameObject.Find("Misery").GetComponent<Misery>();

        if (!onCoooldown)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    #endregion
    //========================


}
