using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fader : MonoBehaviour
{
    float fadeInSpeed = 0.5f;
    float fadeOutSpeed = -0.5f;
    public float fadeAlpha = 0;
    public bool fadingIn = false;
    public bool fadingOut = false;
    public float progression;

    [SerializeField] bool isRenderer;
    [SerializeField] bool isImage;
    [SerializeField] bool isText;

    [SerializeField] SpriteRenderer renderer;
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI text;

    [SerializeField] Fader coverRectFader;
    [SerializeField] Fader invasionTxt1Fader;
    [SerializeField] Fader invasionTxt2Fader;

    [SerializeField] GameObject[] invasionObjects;

    Color aimColor;

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

            if (fadeAlpha >= 1)
            {
                fadingIn = false;
            }
        }

        if (fadeSpeed < 0)
        {
            aimAlpha = 0;

            if (fadeAlpha <= 0)
            {
                fadingOut = false;
            }
        }

        fadeAlpha = Mathf.MoveTowards(fadeAlpha, aimAlpha, Mathf.Abs(fadeSpeed * Time.deltaTime));
    }

    // Start is called before the first frame update
    void Start()
    {
        if (isRenderer)
        {
            aimColor = renderer.color;
        }

        if (isImage)
        {
            aimColor = image.color;
        }

        if (isText)
        {
            aimColor = text.color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fadingIn)
        {
            Fade(fadeInSpeed);

            if (isRenderer)
            {
                renderer.color = new Color(aimColor.r, aimColor.g, aimColor.b, fadeAlpha);
            }

            if (isImage)
            {
                image.color = new Color(aimColor.r, aimColor.g, aimColor.b, fadeAlpha);
            }

            if (isText)
            {
                text.color = new Color(aimColor.r, aimColor.g, aimColor.b, fadeAlpha);
            }
        }

        if (fadingOut)
        {
            Fade(fadeOutSpeed);

            if (isRenderer)
            {
                renderer.color = new Color(aimColor.r, aimColor.g, aimColor.b, fadeAlpha);
            }

            if (isImage)
            {
                image.color = new Color(aimColor.r, aimColor.g, aimColor.b, fadeAlpha);
            }

            if (isText)
            {
                text.color = new Color(aimColor.r, aimColor.g, aimColor.b, fadeAlpha);
            }
        }

        //INVASION SCENE PROGRESSION
        if (name == coverRectFader.gameObject.name)
        {
            //step 1
            if (fadeAlpha >= 1)
            {
                if (progression == 0)
                {
                    progression = 1;
                }
            }

            //step 5
            if (progression == 2)
            {
                fadingIn = true;

                if (fadeAlpha >= 1 && invasionTxt1Fader.progression == 2)
                {
                    foreach (GameObject @object in invasionObjects)
                    {
                        @object.SetActive(false);
                    }

                    invasionTxt1Fader.progression = 3;
                }
            }

            //step 8
            if (progression == 3)
            {
                fadingOut = true;

                if (fadeAlpha <= 0 && invasionTxt1Fader.fadeAlpha <= 0 && invasionTxt2Fader.fadeAlpha <= 0)
                {
                    Destroy(transform.parent.transform.parent.gameObject);
                }
            }
        }

        if (name == invasionTxt1Fader.gameObject.name)
        {
            //step 2
            if (coverRectFader.progression == 1 && progression == 0)
            {
                if (fadeAlpha < 1)
                {
                    fadingIn = true;
                }

                else
                {
                    progression = 1;
                    fadeOutSpeed = -0.2f;
                    fadingOut = true;
                }
            }

            //step 3
            if (progression == 1)
            {
                if (fadeAlpha <= 0)
                {
                    coverRectFader.fadingOut = true;

                    foreach (GameObject @object in invasionObjects)
                    {
                        @object.SetActive(true);
                    }

                    if (coverRectFader.fadeAlpha <= 0)
                    {
                        coverRectFader.gameObject.SetActive(false);
                    }
                }
            }

            //step 4
            if (progression == 2)
            {
                coverRectFader.gameObject.SetActive(true);
                coverRectFader.progression = 2;
            }

            //step 6
            if (progression == 3)
            {
                fadingIn = true;
                
                if (fadeAlpha >= 1)
                {
                    invasionTxt2Fader.fadingIn = true;
                    progression = 4;
                }
            }

            //step 7
            if (progression == 4)
            {
                if (invasionTxt2Fader.fadeAlpha >= 1)
                {
                    fadeOutSpeed = -0.2f;
                    fadingOut = true;

                    invasionTxt2Fader.fadeOutSpeed = -0.2f;
                    invasionTxt2Fader.fadingOut = true;
                }

                if (invasionTxt1Fader.fadeAlpha <= 0.5 && invasionTxt2Fader.fadeAlpha <= 0.5)
                {
                    coverRectFader.progression = 3;
                }
            }
        }

        if (name == invasionTxt2Fader.gameObject.name)
        {

        }
    }
}
