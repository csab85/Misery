using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    [SerializeField] GameObject baseInvasion;
    [SerializeField] DialogueControlGhost dcGhost;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject fadeRect;
    [SerializeField] float fadeSpeed;
    float alpha = 0;

    public void CarregarCenaBaseInvader()
    {
        dcGhost.NextSentence();

        GameObject.Find("Misery").GetComponent<Misery>().invading = true;

        mainCamera.GetComponent<MainCamera>().Fade(0.5f);

        Instantiate(baseInvasion, mainCamera.transform);
    }
}
