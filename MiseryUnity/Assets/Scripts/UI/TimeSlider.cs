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

    float aimTimeValue;

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
    }

    //Update
    void Update()
    {
        timeValue = Mathf.MoveTowards(timeValue, aimTimeValue, growthSpeed * Time.deltaTime);
        slider.value = timeValue;

        intTimeValue = (int)timeValue;

        timeCounter.text = intTimeValue.ToString();
    }

    #endregion
    //========================


}
