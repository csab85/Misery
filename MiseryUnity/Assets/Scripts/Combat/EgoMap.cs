using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EgoMap : MonoBehaviour
{
    //IMPORTS
    //========================
    #region
    [SerializeField] Misery miseryScript;

    public GameObject cam;

    public GameObject spawner;

    [SerializeField] TimeSlider timeSliderScript;
    [SerializeField] SpriteRenderer fadeRectRenderer;
    [SerializeField] TextMeshProUGUI invasionText;

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

    public float fadeAlpha = 0;
    public bool fading = false;
    public bool unfading = false;
    public float textFadeAlpha = 1;
    public bool textFading = false;
    public bool textUnfading = false;

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
    void  AddObstacle(GameObject obstacle, int times)
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


    /// <summary>
    /// Fades or unfades the camera to black
    /// </summary>
    /// <param name="fadeSpeed">How quick will the camera fade (if positive) or unfade (if negative)</param>
    public void Fade(float fadeSpeed)
    {
        float aimAlpha = 0;

        if (fadeSpeed > 0)
        {
            aimAlpha = 1;
        }

        if (fadeSpeed < 0)
        {
            aimAlpha = 0;
        }

        fadeAlpha = Mathf.MoveTowards(fadeAlpha, aimAlpha, Mathf.Abs(fadeSpeed * Time.deltaTime));

        fadeRectRenderer.color = new Color(0, 0, 0, fadeAlpha);
    }

    public void TextFade(float fadeSpeed)
    {
        float aimAlpha = 0;

        if (fadeSpeed > 0)
        {
            aimAlpha = 1;
        }

        if (fadeSpeed < 0)
        {
            aimAlpha = 0;
        }

        textFadeAlpha = Mathf.MoveTowards(textFadeAlpha, aimAlpha, Mathf.Abs(fadeSpeed * Time.deltaTime));

        invasionText.color = new Color(1, 1, 1, textFadeAlpha);
    }

    #endregion
    //========================


    //RUNNING
    //========================
    #region

    //Start
    void Start()
    {
        Mathf.Clamp(fadeAlpha, 0, 1);
        Mathf.Clamp(textFadeAlpha, 0, 1);
        deck = new List<GameObject> { allyShooter, allyMage, allyTank };
        miseryScript = GameObject.Find("Misery").GetComponent<Misery>();
        cam = GameObject.Find("MainCamera");
        ChooseTroops();
        AddObstacle(spawner, 3);
    }

    //Update
    void Update()
    {
        if (fading)
        {
            Fade(0.5f);
        }

        if (unfading)
        {
            Fade(-0.5f);
        }

        if (textFading)
        {
            TextFade(0.5f);
        }

        if (textUnfading)
        {
            TextFade(-0.5f);
        }

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
        #endregion
    }

    #endregion
    //========================
}
