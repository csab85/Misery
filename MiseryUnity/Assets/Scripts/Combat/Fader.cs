using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    Misery miseryScript;

    float fadeInSpeed = 0.5f;
    float fadeOutSpeed = -0.5f;
    public float fadeAlpha = 0;
    public bool fadingIn = false;
    public bool fadingOut = false;
    public float progression;

    [SerializeField] bool isRenderer;
    [SerializeField] bool isImage;
    [SerializeField] bool isText;

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI text;

    [SerializeField] Fader coverRectFader;
    [SerializeField] Fader invasionTxt1Fader;
    [SerializeField] Fader invasionTxt2Fader;

    [SerializeField] GameObject[] invasionObjects;

    Color aimColor;

    //SOUL STORIES
    string[] story1 = { "Meu tio estava agindo estranho comigo na minha festa de 10 anos...", "Ele conseguiu.", "Mudei-me para outro país com meus pais depois do meu aniversário de 10 anos." };

    string[] story2 = { "Eu estava afundado em dívidas, a empresa da família ia falir...", "E faliu, fui despejado e minha família passa fome.", "E faliu, fui despejado e minha família passa fome." };

    string[] story3 = { "Saí do meu país em busca de uma vida melhor...", "E fui enganada, tive que fazer de tudo para sobreviver.", "Com muito trabalho duro consegui reconstruir minha vida novamente." };

    string[] story4 = { "Acusei outra pessoa por um crime que eu cometi...", "Acabei preso, peguei sentença de 12 anos.", "Safei-me, consegui colocar outra pessoa na cadeia." };

    string[] story5 = { "Após trabalhar duro desde os 12 anos, consegui investir na minha casa própria...", "Mas a perdi para o banco e fui demitido do meu trabalho atual.", "Após muitos empréstimos, tenho casa própria." };

    string[] story6 = { "Encontrei o amor da minha vida, o problema é que sou casado...", "Minha esposa descobriu, me acovardei e deixei ela ir.", "Criei coragem e pedi o divórcio." };

    string[] story7 = { "Meu chefe estava sendo um escroto comigo...", "Mas eu precisava muito do dinheiro, então aguentei.", "Pedi demissão e consegui um emprego muito melhor." };

    string[] story8 = { "Estava me sentindo mal e fui ao médico fazer exames...", "Preciso de dinheiro para um tratamento caro.", "Não teve alteração nenhuma." };

    string[] story9 = { "Cometi um erro no trabalho...", "Descobriram e fui demitido.", "Fiz outra pessoa ser demitida no meu lugar." };

    string[] story10 = { "Quando tinha 15 anos me meti numa furada com um pessoal...", "Acabei em uma enrascada e tive que fugir de casa.", "Consegui pagar o que lhes devia e me deixaram em paz." };

    string[] timeStory = { "Você desafiou o Tempo...", "E venceu, por enquanto...", "Mais um erro que você não vai corrigir" };

    string[][] stories;

    public string[] chosenStroy;

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

        miseryScript = GameObject.Find("Misery").GetComponent<Misery>();
        if (isRenderer)
        {
            aimColor = spriteRenderer.color;
        }

        if (isImage)
        {
            aimColor = image.color;
        }

        if (isText)
        {
            aimColor = text.color;

            stories = new string[][] { story1, story2, story3, story4, story5, story6, story7, story8, story9, story10 };

            chosenStroy = stories[Random.Range(0, 10)];

            if (miseryScript.battleLvl == 4)
            {
                chosenStroy = timeStory;
            }

            gameObject.GetComponent<TextMeshProUGUI>().text = chosenStroy[0];
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
                spriteRenderer.color = new Color(aimColor.r, aimColor.g, aimColor.b, fadeAlpha);
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
                spriteRenderer.color = new Color(aimColor.r, aimColor.g, aimColor.b, fadeAlpha);
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

            //step 8 final
            if (progression == 3)
            {
                fadingOut = true;

                if (fadeAlpha <= 0 && invasionTxt1Fader.fadeAlpha <= 0 && invasionTxt2Fader.fadeAlpha <= 0)
                {
                    if (miseryScript.battleLvl == 4)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    }

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
