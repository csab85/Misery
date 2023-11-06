using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EgoMap : MonoBehaviour
{
    //IMPORTS
    //========================
    #region
    public GameObject rock;
    public GameObject trap;
    public GameObject spawner;

    public GameObject camera;

    //classes
    public GameObject allyShooter;
    public GameObject allyMage;
    public GameObject allyTank;

    public GameObject enemyShooter;
    public GameObject enemyMage;
    public GameObject enemyTank;

    GameObject selectedUnit;

    #endregion
    //========================


    //STATS AND VALUES
    //========================
    #region

    public int shootersAvaiable = 0;
    public int magesAvaiable = 0;
    public int tanksAvaiable = 0;

    public List<GameObject> deck;

    //Functions progress
    public bool obstacled = true;

    int rockCounter = 0;

    #endregion
    //========================


    //FUNCTIONS
    //========================
    #region

    /// <summary>
    /// Adds obstacles to the map
    /// </summary>
    /// <param name="obstacle">The type of obstacle to be added</param>
    /// <param name="minimumPoint">The minimun point x and y in which the obstacles will appear (Max is the map border)</param>
    /// <param name="times">How much times the obstacle will be spawned</param>
    /// <returns></returns>
    void  AddObstacle(GameObject obstacle, Vector2 minimumPoint, int times)
    {
        Vector2 posit;

        for (int i = 0; i < times; i++)
        {
            posit.x = Random.Range(minimumPoint.x, 7);
            posit.y = Random.Range(minimumPoint.y, 7);

            Instantiate(obstacle, posit, Quaternion.identity);
            rockCounter += 1;
        }

        obstacled = true;
    }

    void ChooseTroops()
    {
        for (int i = 0; i < 16; i++)
        {
            GameObject chosenUnit = deck[Random.Range(0, 3)];

            if (chosenUnit == allyShooter)
            {
                shootersAvaiable += 1;
                continue;
            }

            if (chosenUnit == allyMage)
            {
                magesAvaiable += 1;
                continue;
            }

            if (chosenUnit == allyTank)
            {
                tanksAvaiable += 1;
                continue;
            }
        }
    }

    #endregion
    //========================


    //RUNNING
    //========================
    #region

    //Start
    void Start()
    {
        deck = new List<GameObject> { allyShooter, allyMage, allyTank };
        ChooseTroops();
    }

    //Update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && shootersAvaiable > 0)
        {
            selectedUnit = allyShooter;
        }

        if (Input.GetKeyDown(KeyCode.S) && magesAvaiable > 0)
        {
            selectedUnit = allyMage;
        }

        if (Input.GetKeyDown(KeyCode.D) && tanksAvaiable > 0)
        {
            selectedUnit = allyTank;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosit = camera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);

            Instantiate(selectedUnit, new Vector3(mousePosit.x, mousePosit.y, -2), Quaternion.identity);

            //discount
            if (selectedUnit == allyShooter)
            {
                shootersAvaiable -= 1;
            }

            if (selectedUnit == allyMage)
            {
                magesAvaiable -= 1;
            }

            if (selectedUnit == allyTank)
            {
                tanksAvaiable -= 1;
            }
        }
    }

    #endregion
    //========================
}
