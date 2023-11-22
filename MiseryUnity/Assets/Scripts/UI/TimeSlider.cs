using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeSlider: MonoBehaviour
{
    //IMPORTS
    //========================
    #region

    [SerializeField] Slider slider;

    [SerializeField] TextMeshProUGUI timeCounter;

    #endregion
    //========================


    //STATS AND VALUES
    //========================
    #region

    public float timeValue;

    [SerializeField] float growthSpeed;
    [SerializeField] float decayMultiplier;
    float normalGrowthSpeed;

    public float aimTimeValue;

    int intTimeValue;

    #endregion
    //========================


    //FUNCTIONS
    //========================
    #region

    #endregion
    //========================


    //RUNNING
    //========================
    #region

    //Start
    void Start()
    {
        aimTimeValue = slider.maxValue;
        normalGrowthSpeed = growthSpeed;
    }

    //Update
    void Update()
    {
        //make it faster when reducing
        if(aimTimeValue < timeValue && growthSpeed == normalGrowthSpeed)
        {
            growthSpeed *= decayMultiplier;
        }

        else
        {
            growthSpeed = normalGrowthSpeed;
        }

        //make it go back to growing after reduced
        if (timeValue == aimTimeValue)
        {
            aimTimeValue = 10;
        }

        //move slider
        timeValue = Mathf.MoveTowards(timeValue, aimTimeValue, growthSpeed * Time.deltaTime);
        slider.value = timeValue;

        intTimeValue = (int)timeValue;

        timeCounter.text = intTimeValue.ToString();
    }

    #endregion
    //========================


}
