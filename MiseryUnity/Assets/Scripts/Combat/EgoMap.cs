using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EgoMap : MonoBehaviour
{
    //IMPORTS
    //========================
    #region
    [SerializeField] Misery miseryScript;

    public GameObject cam;

    public GameObject spawner;

    [SerializeField] TimeSlider timeSliderScript;
    public TextMeshProUGUI invasionText;

    //classes
    public GameObject allyShooter;
    public GameObject allyMage;
    public GameObject allyTank;

    public GameObject enemyShooter;
    public GameObject enemyMage;
    public GameObject enemyTank;

    public GameObject selectedUnit;

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
    float rockCounter;

    public bool showingCard = false;

    //list with units to delete
    public List<GameObject> activeUnits;

    //spawners list
    [SerializeField] GameObject[] spawnersLvl1;
    [SerializeField] GameObject[] spawnersLvl2;
    [SerializeField] GameObject[] spawnersLvl3;
    [SerializeField] GameObject[] bossObjects;

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
    void  AddObstacle()
    {
        if (miseryScript.battleLvl == 1)
        {
            foreach (GameObject spawner in spawnersLvl1)
            {
                spawner.SetActive(true);
            }
        }

        if (miseryScript.battleLvl == 2)
        {
            foreach (GameObject spawner in spawnersLvl2)
            {
                spawner.SetActive(true);
            }
        }

        if (miseryScript.battleLvl == 3)
        {
            foreach (GameObject spawner in spawnersLvl3)
            {
                spawner.SetActive(true);
            }
        }

        if (miseryScript.battleLvl == 4)
        {
            foreach (GameObject @object in bossObjects)
            {
                @object.SetActive(true);
            }
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
        miseryScript = GameObject.Find("Misery").GetComponent<Misery>();
        cam = GameObject.Find("MainCamera");
        ChooseTroops();
        AddObstacle();
    }

    //Update
    void Update()
    {
        //Control
        #region

        if (Input.GetKeyDown(KeyCode.A))
        {
            selectedUnit = allyMage;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            selectedUnit = allyShooter;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            selectedUnit = allyTank;
        }

        if (Input.GetMouseButtonDown(0) && !showingCard)
        {
            Vector3 mousePosit = cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);

            float unitCost = selectedUnit.GetComponent<UnitBehaviour>().cost;

            //discount
            if (selectedUnit == allyShooter && shootersAvaiable > 0 && timeSliderScript.timeValue >= unitCost)
            {
                activeUnits.Add(Instantiate(selectedUnit, new Vector3(mousePosit.x + 0.3f, mousePosit.y, -2), Quaternion.identity));
                activeUnits.Add(Instantiate(selectedUnit, new Vector3(mousePosit.x - 0.3f, mousePosit.y, -2), Quaternion.identity));
                activeUnits.Add(Instantiate(selectedUnit, new Vector3(mousePosit.x, mousePosit.y + 0.3f, -2), Quaternion.identity));
                activeUnits.Add(Instantiate(selectedUnit, new Vector3(mousePosit.x, mousePosit.y - 0.3f, -2), Quaternion.identity));

                timeSliderScript.aimTimeValue = timeSliderScript.timeValue - unitCost;
                shootersAvaiable -= 1;
            }

            if (selectedUnit == allyMage && magesAvaiable > 0 && timeSliderScript.timeValue >= unitCost)
            {
                activeUnits.Add(Instantiate(selectedUnit, new Vector3(mousePosit.x, mousePosit.y, -2), Quaternion.identity));

                timeSliderScript.aimTimeValue = timeSliderScript.timeValue - unitCost;
                magesAvaiable -= 1;
            }

            if (selectedUnit == allyTank && tanksAvaiable > 0 && timeSliderScript.timeValue >= unitCost)
            {
                activeUnits.Add(Instantiate(selectedUnit, new Vector3(mousePosit.x, mousePosit.y, -2), Quaternion.identity));

                timeSliderScript.aimTimeValue = timeSliderScript.timeValue - unitCost;
                tanksAvaiable -= 1;
            }
        }

        if (!miseryScript.invading)
        {
            Destroy(transform.parent);
        }
        #endregion
    }

    #endregion
    //========================
}
