using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    [SerializeField] GameObject baseInvasion;
    [SerializeField] DialogueControlGhost dcGhost;
    [SerializeField] GameObject mainCamera;

    public void CarregarCenaBaseInvader()
    {
        dcGhost.NextSentence();

        GameObject.Find("Misery").GetComponent<Misery>().invading = true;

        GameObject.Find("Misery").GetComponent<Misery>().enemySoul.GetComponent<Soul>().speed = 0;

        Instantiate(baseInvasion, mainCamera.transform);
    }
}
