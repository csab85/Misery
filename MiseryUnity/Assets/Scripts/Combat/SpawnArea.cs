using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    [SerializeField] EgoMap egoMapScript;
    [SerializeField] Card mageCard;
    [SerializeField] Card shootersCard;
    [SerializeField] Card tankCard;

    // Start is called before the first frame update
    private void OnMouseEnter()
    {
        if(mageCard.hide && shootersCard.hide && tankCard.hide)
        {
            egoMapScript.showingCard = false;
        }
    }

    private void OnMouseExit()
    {
        egoMapScript.showingCard = true;
    }
}
