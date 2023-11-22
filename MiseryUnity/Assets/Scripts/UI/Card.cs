using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    //IMPORTS
    //========================
    #region

    [SerializeField] EgoMap egoMapScript;
    [SerializeField] Button cardButton;
    [SerializeField] GameObject unit;
    [SerializeField] UnitBehaviour unitScript;
    [SerializeField] TextMeshProUGUI type;
    [SerializeField] TextMeshProUGUI cost;
    [SerializeField] TextMeshProUGUI damage;
    [SerializeField] TextMeshProUGUI health;

    #endregion
    //========================


    //STATS AND VALUES
    //========================
    #region

    [SerializeField] float travelSpeed;
    [SerializeField] float growthSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float showHeight;

    RectTransform rectTransform;

    public Vector3 normalPosit;
    Vector3 normalScale;
    Vector3 normalRotation;
    int normalSibilingIndex;

    public Vector3 posit;
    Vector3 scale;
    Vector3 rotation;

    bool show = false;
    bool hide = false;

    //gambiarra to correct position based on resolution
    float lastScreenX;

    #endregion
    //========================


    //FUNCTIONS
    //========================
    #region

    /// <summary>
    /// Makes the card go up and get bigger so the player can read it
    /// </summary>
    void ShowCard()
    {
        //calculate values
        posit.y = Mathf.MoveTowards(posit.y, (normalPosit.y + showHeight), travelSpeed * Time.deltaTime);

        scale.x = Mathf.MoveTowards(scale.x, 3.5f, growthSpeed * Time.deltaTime);
        scale.y = Mathf.MoveTowards(scale.y, 3.5f, growthSpeed * Time.deltaTime);

        rotation.z = Mathf.MoveTowardsAngle(rotation.z, 0, rotationSpeed * Time.deltaTime);

        //update in editor
        rectTransform.anchoredPosition = posit;
        rectTransform.localScale = scale;
        rectTransform.rotation = Quaternion.Euler(rotation);
        rectTransform.SetAsLastSibling();

        if (posit == normalPosit && scale == normalScale && rotation == normalRotation)
        {
            show = false;
        }
    }

    /// <summary>
    /// Makes the card go back to its original place
    /// </summary>
    void HideCard()
    {
        //calculate values
        posit.y = Mathf.MoveTowards(posit.y, normalPosit.y, travelSpeed * Time.deltaTime);

        scale.x = Mathf.MoveTowards(scale.x, normalScale.x, growthSpeed * Time.deltaTime);
        scale.y = Mathf.MoveTowards(scale.y, normalScale.y, growthSpeed * Time.deltaTime);

        rotation.z = Mathf.MoveTowardsAngle(rotation.z, normalRotation.z, rotationSpeed * Time.deltaTime); ;

        //update in editor
        rectTransform.anchoredPosition = posit;
        rectTransform.localScale = scale;
        rectTransform.rotation = Quaternion.Euler(rotation);
        rectTransform.SetSiblingIndex(normalSibilingIndex);

        if (posit == normalPosit && scale == normalScale && rotation == normalRotation)
        {
            hide = false;
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

        //handle card positioning
        rectTransform = GetComponent<RectTransform>();

        normalPosit = rectTransform.anchoredPosition;
        normalScale = rectTransform.localScale;
        normalRotation = rectTransform.rotation.eulerAngles;
        normalSibilingIndex = rectTransform.GetSiblingIndex();

        posit = normalPosit;
        scale = normalScale;
        rotation = normalRotation;

        //set card values
        type.text = unitScript.type;
        cost.text = unitScript.cost.ToString();
        damage.text = unitScript.damage.ToString();
        health.text = unitScript.health.ToString();
    }

    //Update
    void Update()
    {
        if (show)
        {
            ShowCard();
        }

        if (hide)
        {
            HideCard();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hide = false;
        show = true;
        egoMapScript.showingCard = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        show = false;
        hide = true;
        egoMapScript.showingCard = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (show)
        {
            egoMapScript.selectedUnit = unit;
        }
    }

    #endregion
    //========================
}